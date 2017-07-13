using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private List<Bender> benders = new List<Bender>();
    private List<Monument> monuments = new List<Monument>();
    private List<string> wars = new List<string>();

    public void AssignBender(List<string> benderArgs)
    {
        var type = benderArgs[0];
        var name = benderArgs[1];
        var power = int.Parse(benderArgs[2]);
        var secondaryParameter = double.Parse(benderArgs[3]);

        Bender bender = null;

        switch (type)
        {
            case "Air":
                bender = new AirBender(name, power, secondaryParameter);
                break;
            case "Water":
                bender = new WaterBender(name, power, secondaryParameter);
                break;
            case "Fire":
                bender = new FireBender(name, power, secondaryParameter);
                break;
            case "Earth":
                bender = new EarthBender(name, power, secondaryParameter);
                break;
        }

        this.benders.Add(bender);
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        var type = monumentArgs[0];
        var name = monumentArgs[1];
        var affinity = int.Parse(monumentArgs[2]);

        Monument monument = null;

        switch (type)
        {
            case "Air":
                monument = new AirMonument(name, affinity);
                break;
            case "Water":
                monument = new WaterMonument(name, affinity);
                break;
            case "Fire":
                monument = new FireMonument(name, affinity);
                break;
            case "Earth":
                monument = new EarthMonument(name, affinity);
                break;
        }

        this.monuments.Add(monument);
    }

    public string GetStatus(string nationsType)
    {
        List<Bender> resultBenders = null;
        List<Monument> resultMonuments = null;

        switch (nationsType)
        {
            case "Air":
                resultBenders = benders.Where(b => b.GetType().Name == "AirBender").ToList();
                resultMonuments = monuments.Where(m => m.GetType().Name == "AirMonument").ToList();
                break;
            case "Water":
                resultBenders = benders.Where(b => b.GetType().Name == "WaterBender").ToList();
                resultMonuments = monuments.Where(m => m.GetType().Name == "WaterMonument").ToList();
                break;
            case "Fire":
                resultBenders = benders.Where(b => b.GetType().Name == "FireBender").ToList();
                resultMonuments = monuments.Where(m => m.GetType().Name == "FireMonument").ToList();
                break;
            case "Earth":
                resultBenders = benders.Where(b => b.GetType().Name == "EarthBender").ToList();
                resultMonuments = monuments.Where(m => m.GetType().Name == "EarthMonument").ToList();
                break;
        }

        return GetStringForNation(nationsType, resultBenders, resultMonuments);
    }

    public void IssueWar(string nationsType)
    {
        wars.Add(nationsType);

        var winner = string.Empty;

        var airTotalPower = this.benders.Where(b => b.GetType().Name == "AirBender").Sum(b => b.CalculatePower());
        var waterTotalPower = this.benders.Where(b => b.GetType().Name == "WaterBender").Sum(b => b.CalculatePower());
        var fireTotalPower = this.benders.Where(b => b.GetType().Name == "FireBender").Sum(b => b.CalculatePower());
        var earthTotalPower = this.benders.Where(b => b.GetType().Name == "EarthBender").Sum(b => b.CalculatePower());

        var airBonus = this.monuments.Where(m => m.GetType().Name == "AirMonument").Sum(m => m.GetBonus());
        var waterBonus = this.monuments.Where(m => m.GetType().Name == "WaterMonument").Sum(m => m.GetBonus());
        var fireBonus = this.monuments.Where(m => m.GetType().Name == "FireMonument").Sum(m => m.GetBonus());
        var earthBonus = this.monuments.Where(m => m.GetType().Name == "EarthMonument").Sum(m => m.GetBonus());

        airTotalPower += (airTotalPower / 100) * airBonus;
        waterTotalPower += (waterTotalPower / 100) * waterBonus;
        fireTotalPower += (fireTotalPower / 100) * fireBonus;
        earthTotalPower += (earthTotalPower / 100) * earthBonus;

        //find winner
        winner = this.FindWinner(airTotalPower, waterTotalPower, fireTotalPower, earthTotalPower);
        benders.RemoveAll(b => !b.GetType().Name.StartsWith(winner[0].ToString()));
        monuments.RemoveAll(m => !m.GetType().Name.StartsWith(winner[0].ToString()));
    }

   
    public string GetWarsRecord()
    {
        var count = 1;
        var sb = new StringBuilder();

        foreach (var war in wars)
        {
            sb.AppendLine($"War {count} issued by {war}");
            count++;
        }

        return sb.ToString();
    }

    private string GetStringForNation(string nationsType, List<Bender> resultBenders, List<Monument> resultMonuments)
    {

        var sb = new StringBuilder();
        sb.AppendLine($"{nationsType} Nation");

        if (resultBenders.Count == 0)
        {
            sb.AppendLine("Benders: None");
        }
        else
        {
            sb.AppendLine("Benders:");
            foreach (var bender in resultBenders)
            {
                sb.AppendLine($"###{bender.ToString()}");
            }
        }

        if (resultMonuments.Count == 0)
        {
            sb.AppendLine("Monuments: None");
        }
        else
        {
            sb.AppendLine("Monuments:");
            foreach (var monument in resultMonuments)
            {
                sb.AppendLine($"###{monument.ToString()}");
            }
        }

        return sb.ToString().Trim();
    }

    private string FindWinner(double airTotalPower, double waterTotalPower, double fireTotalPower, double earthTotalPower)
    {
        var values = new List<double> { airTotalPower, waterTotalPower, fireTotalPower, earthTotalPower };
        var max = double.MinValue;

        foreach (var value in values)
        {
            if (value > max)
            {
                max = value;
            }
        }

        if (max == airTotalPower)
        {
            return "Air";
        }
        if (max == waterTotalPower)
        {
            return "Water";
        }
        if (max == fireTotalPower)
        {
            return "Fire";
        }
        return "Earth";
    }
}