namespace APiServer.Dao
{
    public class dbConecxion
    {
        private string CadenaConecxion = string.Empty;
        public dbConecxion()
        {
            var Buider = new ConfigurationBuilder().SetBasePath(

                Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            CadenaConecxion = Buider.GetSection("ConnectionStrings:DefaultConnection").Value;

        }

        public string CadenaConecxionSQL()
        {
            return CadenaConecxion;
        }
    }
}
