
namespace CodeFirst.Data
{
    public static class DataValidations
    {
        public static class Patient
        {
            public const int maxNameLength = 50;
            public const int maxAddressLength = 250;
        }

        public static class Visitation
        {
            public const int maxCommentLength = 250;
        }

        public static class Diagnose
        {
            public const int maxNameLength = 50;
            public const int maxCommentLength = 250;
        }

        public static class Medicament
        {
            public const int maxNamelength = 50;
        }

        public static class Doctor
        {
            public const int maxNameLength = 50;
            public const int maxSpecialtyLength = 30;
        }
    }
}
