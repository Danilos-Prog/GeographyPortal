namespace GeographyPortal.Models
{
    public class PortalGeographyMongoDBSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ExerciseCollectionName { get; set; } = null!;

        public string TestCollectionName { get; set; } = null!;
    }
}
