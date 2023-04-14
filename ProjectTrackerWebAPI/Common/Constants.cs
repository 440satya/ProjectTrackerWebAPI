using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Project.Common
{
    public static class Constants
    {
        public const string WebsiteDomain = "https://www.ProjectTracker.com";

        public const int DefaultSortOrder = 10;
        public const int IndiaCountryId = 101;

        public const int ShortDescriptionMaxLength = 700;
        public const int SloganMaxLength = 200;

        public const string DefaultDateFormat = "{0:dd/MM/yyyy}";
        public const string TempFilesPath = "tempFiles";

        private const string errorOccured = "Error occured while processing your request.";
        public static string ErrorOccured => errorOccured;

        public const string XMLNameSpace = "http://www.sitemaps.org/schemas/sitemap/0.9";
        public static string RootFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        public static string ImageFolderWithRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        public static string ImageFolder = "images";

        private const int defaultPageSize = 20; //Number of records to show on single page
        public static int DefaultPageSize => defaultPageSize;

        public static string[] supportedImageTypes = new[] { "jpg", "jpeg", "png" };
        public static string[] supportedFileTypes = new[] { "txt", "doc", "docx", "pdf", "xls", "xlsx" };

        public enum OperationType
        {
            Add,
            Edit,
            Delete
        }

        public enum FeedBackType
        {
            Feedback,
            Complaint
        }

        public enum CostMetrics
        {
            [Display(Name = "Thousand")]
            Thousand = 0,

            [Display(Name = "Lakh")]
            Lakh = 1,

            [Display(Name = "Crore")]
            Crore = 2
        }

        public enum CurrentStatus
        {
            [Display(Name = "ToDo")]
            ToDo = 0,

            [Display(Name = "In Progress")]
            InProgress = 1,

            [Display(Name = "Done")]
            Done = 2
        }

        public enum FileStatus
        {
            [Display(Name = "New")]
            New = 0,

            [Display(Name = "In Progress")]
            InProgress = 1,

            [Display(Name = "ReMarked")]
            ReMarked = 2,

            [Display(Name = "Completed")]
            Done = 3
        }
        public enum Roles
        {
            SuperAdmin,
            Admin,
            Basic
        }
    }
}
