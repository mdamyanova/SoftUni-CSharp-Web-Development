namespace MassDefect.Import
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            //JsonImport.ImportSolarSystems();
            //JsonImport.ImportStars();
            //JsonImport.ImportPlanets();
            //JsonImport.ImportPeople();
            //JsonImport.ImportPeople();
            //JsonImport.ImportAnomalies();
            //JsonImport.ImportVictims();
            XmlImport.ImportAnomalies();
        }
    }
}