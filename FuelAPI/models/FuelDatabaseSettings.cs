namespace FuelAPI.models
{
    public class FuelDatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string FuelUserCollectionName { get; set; } = string.Empty;
        public string vehicleownerCollectionName { get; set; } = string.Empty;
    }
}
