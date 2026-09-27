using FutureTechAcademy.Models;
using FutureTechAcademy.Services;
using Microsoft.AspNetCore.Mvc;

namespace FutureTechAcademy.Controllers
{
    // [Authorize] // Uncomment this after configuring your OAuth provider (Google/GitHub/Firebase)
    public class StudentsController : Controller
    {
        private readonly ICosmosService _cosmosService;
        private readonly IBlobService _blobService;

        public StudentsController(ICosmosService cosmosService, IBlobService blobService)
        {
            _cosmosService = cosmosService;
            _blobService = blobService;
        }

        // 1. VIEW ALL STUDENTS (Dashboard)
        public async Task<IActionResult> Index(string searchString)
        {
            // Fetch all records from Cosmos DB
            var students = await _cosmosService.GetStudentsAsync();

            // Search Logic (Requirement: Search by Name, Surname, or ID)
            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                            || s.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                            || s.Id.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Secure Image Handling: Convert raw filenames to temporary SAS URLs for the browser
            foreach (var student in students)
            {
                if (!string.IsNullOrEmpty(student.ProfileImageUrl))
                {
                    student.ProfileImageUrl = await _blobService.GetSecureSasUrl(student.ProfileImageUrl);
                }
            }

            return View(students);
        }

        // 2. ADD STUDENT (GET)
        public IActionResult Create()
        {
            return View();
        }

        // 3. ADD STUDENT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student, IFormFile? profilePicture)
        {
            // Requirement: Ensure unique ID (GUID)
            if (string.IsNullOrEmpty(student.Id))
            {
                student.Id = Guid.NewGuid().ToString();
            }

            // Requirement: File Handling (Azure Blob Storage)
            if (profilePicture != null && profilePicture.Length > 0)
            {
                // Dynamic extension handling (.jpg, .png, etc.)
                string extension = Path.GetExtension(profilePicture.FileName);
                string fileName = $"{student.Id}{extension}";

                // Upload to Azure
                await _blobService.UploadImageAsync(profilePicture, fileName);

                // Store ONLY the filename in Cosmos DB (to save costs and keep data clean)
                student.ProfileImageUrl = fileName;
            }

            // Save to Cosmos DB
            await _cosmosService.AddStudentAsync(student);

            // Redirect back to Dashboard
            return RedirectToAction(nameof(Index));
        }

        // 4. EDIT STUDENT (GET)
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var student = await _cosmosService.GetStudentByIdAsync(id);
            if (student == null) return NotFound();

            // Requirement: Use SAS tokens for secure viewing in the edit preview
            if (!string.IsNullOrEmpty(student.ProfileImageUrl))
            {
                student.ProfileImageUrl = await _blobService.GetSecureSasUrl(student.ProfileImageUrl);
            }

            return View(student);
        }

        // 5. EDIT STUDENT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Student student, IFormFile? profilePicture)
        {
            if (id != student.Id) return NotFound();

            try
            {
                // Fetch the existing record from Cosmos DB to check the previous image
                var existingStudent = await _cosmosService.GetStudentByIdAsync(id);

                if (profilePicture != null && profilePicture.Length > 0)
                {
                    // New image uploaded: Replace the old one
                    string extension = Path.GetExtension(profilePicture.FileName);
                    string fileName = $"{student.Id}{extension}";
                    await _blobService.UploadImageAsync(profilePicture, fileName);
                    student.ProfileImageUrl = fileName;
                }
                else
                {
                    // No new image: Keep the existing filename from the database
                    // This prevents saving a SAS URL back into the database
                    student.ProfileImageUrl = existingStudent.ProfileImageUrl;
                }

                // Update Cosmos DB record
                await _cosmosService.UpdateStudentAsync(student);

                // Auto-redirect to Dashboard
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "System Error: Unable to sync changes to Azure Cosmos DB.");
                return View(student);
            }
        }

        // 6. DELETE STUDENT (Soft Delete Requirement)
        public async Task<IActionResult> Delete(string id)
        {
            var student = await _cosmosService.GetStudentByIdAsync(id);
            if (student == null) return NotFound();

            // Requirement: "Option to soft delete (mark as inactive)"
            student.EnrolmentStatus = "Inactive";
            await _cosmosService.UpdateStudentAsync(student);

            return RedirectToAction(nameof(Index));
        }

        // 7. PERMANENT DELETE (Optional Requirement)
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _cosmosService.DeleteStudentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}