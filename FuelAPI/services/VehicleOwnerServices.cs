using FuelAPI.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FuelAPI.services
{
    public class VehicleOwnerServices
    {
        private readonly IMongoCollection<VehicleOwner> _vehicleowner;


        public VehicleOwnerServices(IOptions<FuelDatabaseSettings> options)
        {


            var mongoClient = new MongoClient(options.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                options.Value.DatabaseName);

            _vehicleowner = mongoDatabase.GetCollection<VehicleOwner>(
                options.Value.vehicleownerCollectionName);
        }


        public async Task<List<VehicleOwner>> Get() =>
            await _vehicleowner.Find(_ => true).ToListAsync();

        public async Task<VehicleOwner> Get(string id) =>
            await _vehicleowner.Find(m => m.Id == id).FirstOrDefaultAsync();

        public async Task Create(VehicleOwner newfueluser) =>
            await _vehicleowner.InsertOneAsync(newfueluser);

        public async Task Update(string id, VehicleOwner updatefueluser) =>
            await _vehicleowner.ReplaceOneAsync(m => m.Id == id, updatefueluser);

        public async Task Remove(string id) =>
            await _vehicleowner.DeleteOneAsync(m => m.Id == id);
    }
}
    