namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateReferenceData : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO MembershipTypes (Id, MembershipName, SignUpFee, DurationInMonths, DiscountRate) VALUES (1, 'Pay As You Go', 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, MembershipName, SignUpFee, DurationInMonths, DiscountRate) VALUES (2, 'Monthly' , 30, 1, 10)");
            Sql("INSERT INTO MembershipTypes (Id, MembershipName, SignUpFee, DurationInMonths, DiscountRate) VALUES (3, 'Quarterly' , 90, 3, 15)");
            Sql("INSERT INTO MembershipTypes (Id, MembershipName, SignUpFee, DurationInMonths, DiscountRate) VALUES (4, 'Annually',  300, 12, 20)");


            Sql("SET IDENTITY_INSERT Genres ON");
            Sql("INSERT INTO Genres (Id, GenreName) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, GenreName) VALUES (2, 'Comedy')");
            Sql("INSERT INTO Genres (Id, GenreName) VALUES (3, 'Family')");
            Sql("INSERT INTO Genres (Id, GenreName) VALUES (4, 'Romance')");

            Sql("SET IDENTITY_INSERT Genres OFF");

        }

        public override void Down()
        {
        }
    }
}
