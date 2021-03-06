﻿using System.Collections.Generic;

namespace GraphicEditor.HelpClasses
{
    /// <summary>
    /// Class with static Constants
    /// </summary>
    public class Constants
    {
        // Constant
        public const string BACK = "back";

        // Constants used in MainWindowViewModel
        public const string MAP = "map";
        public const string LOGIN = "login";
        public const string BUILDING = "building";
        public const string PROFILE = "profile";

        // Constants used in HospitalMapUserControlViewModel
        public const string EMERGENCY = "emergency";
        public const string CARDIOLOGY = "cardiology";
        public const string ORTHOPEDICS = "orthopedics";
        public const string PEDIATRICS = "pediatrics";
        public const string DERMATOLOGY = "dermatology";
        public const string ONCOLOGY = "oncology";
        public const string EMPTY_FIELD = "emptyField";

        // Constants used for building floors
        public static readonly Dictionary<string, string> FLOOR_MAP = new Dictionary<string, string>()
        {
            {FIRST, "First floor"},
            {SECOND, "Second floor" }
        };

        public const string FIRST = "first";
        public const string SECOND = "second";

        public static readonly List<string> FLOOR_NAMES = new List<string>()
        { "Ground floor",
          "First floor",
          "Second floor",
          "Third floor",
          "Fourth floor",
          "Fifth floor",
          "Sixth floor"
        };

        public const string EQUIPMENT = "Equipment";
        public const string MEDICINES = "Medicines";
        public const string BEDS = "Beds";
    }
}
