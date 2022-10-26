using Microsoft.Extensions.Options;
using MongoDB.Driver;
using FuelAPI.models;

namespace FuelAPI.services
{
    public class FuelUserServices
    {
        private readonly IMongoCollection<FuelUser> _fueluser;


        public FuelUserServices(IOptions<FuelDatabaseSettings> options)
        {
            //var mongoClient = new MongoClient(options.Value.ConnectionString);

            //_fueluser = mongoClient.GetDatabase(options.Value.DatabaseName)
               // .GetCollection<FuelUser>(options.Value.FuelUserCollectionName);


            var mongoClient = new MongoClient(options.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                options.Value.DatabaseName);

            _fueluser = mongoDatabase.GetCollection<FuelUser>(
                options.Value.FuelUserCollectionName);
        }

        public async Task<List<FuelUser>> Get() =>
            await _fueluser.Find(_ => true).ToListAsync();

        public async Task<FuelUser> Get(string id) =>
            await _fueluser.Find(m => m.Id == id).FirstOrDefaultAsync();

        public async Task Create(FuelUser newfueluser) =>
            await _fueluser.InsertOneAsync(newfueluser);

        public async Task Update(string id, FuelUser updatefueluser) =>
            await _fueluser.ReplaceOneAsync(m => m.Id == id, updatefueluser);

        public async Task Remove(string id) =>
            await _fueluser.DeleteOneAsync(m => m.Id == id);
    }
}
