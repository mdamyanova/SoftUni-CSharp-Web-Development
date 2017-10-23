namespace Sales.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultValueSales : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Sales", "Date", d => d.DateTime(defaultValueSql: "GETDATE()"));
        }
        
        public override void Down()
        {
            AlterColumn("Sales", "Date", d => d.DateTime(defaultValue: null));
        }
    }
}