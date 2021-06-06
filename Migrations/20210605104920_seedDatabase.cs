using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingTest.Migrations
{
    public partial class seedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql("INSERT INTO dbo.Users (Id,FirstName,LastName,Age,Sex,AddedById,IsAdmin,CreatedDate) VALUES ('FA6DE0F1-A8CA-4629-A13D-A911448F7EFA','John','Doe',32,'M',null,1,'2021-06-01 23:37:48.247')");
            migrationBuilder.Sql(@"INSERT INTO dbo.Users (Id,FirstName,LastName,Email,Password,Age,Sex,AddedById,IsAdmin,CreatedDate) VALUES ('921195D1-8675-471A-875B-377971FAC86B','Bruce','Willis','admin@mail.com','Admin',35,'M',null,0,'2021-06-01 23:37:48.247')");
            migrationBuilder.Sql(@"INSERT INTO dbo.Users (Id,FirstName,LastName,Email,Password,Age,Sex,AddedById,IsAdmin,CreatedDate) VALUES ('777F10F9-4DCD-4557-B53D-1A1BA568B666','The','Rock','employee1@mail.com','Employee',33,'M',null,0,'2021-06-01 23:37:48.247')");
            migrationBuilder.Sql(@"INSERT INTO dbo.Users (Id,FirstName,LastName,Email,Password,Age,Sex,AddedById,IsAdmin,CreatedDate) VALUES ('07BB8B12-B209-4768-80CB-3AF840BFEBB9','Adam','Sandler','employee2@mail.com','Employee',44,'M',null,1,'2021-06-01 23:37:48.247')");

            migrationBuilder.Sql("INSERT INTO Reviews (Id,Point,FeedBack,ReviewedDate,ReviewerId,GotReviewedId) VALUES ('1E4B67A4-B2C6-44B9-A0FD-5271A519FEEF',8,'','2021-06-01 23:37:48.247','921195D1-8675-471A-875B-377971FAC86B','777F10F9-4DCD-4557-B53D-1A1BA568B666')");
            migrationBuilder.Sql("INSERT INTO Reviews (Id,Point,FeedBack,ReviewedDate,ReviewerId,GotReviewedId) VALUES ('B0F773B0-8F91-43D1-89CB-A49DD518ED89',7,'Nothing','2021-06-01 23:37:48.247','777F10F9-4DCD-4557-B53D-1A1BA568B666','921195D1-8675-471A-875B-377971FAC86B')");

            migrationBuilder.Sql("INSERT INTO EmployeeAssignedReviews (Id,ReviewerId,ToBeReviewedId,AssignedById,AssignedDate) VALUES" +
                " ('235C6DF3-5916-48DA-8EC1-071E81477D7E','921195D1-8675-471A-875B-377971FAC86B','777F10F9-4DCD-4557-B53D-1A1BA568B666','921195D1-8675-471A-875B-377971FAC86B','2021-06-01 23:37:48.247')");
            migrationBuilder.Sql("INSERT INTO EmployeeAssignedReviews (Id,ReviewerId,ToBeReviewedId,AssignedById,AssignedDate) VALUES " +
                "('80BD71ED-26B4-4CD1-B4A4-534192530430','777F10F9-4DCD-4557-B53D-1A1BA568B666','921195D1-8675-471A-875B-377971FAC86B','921195D1-8675-471A-875B-377971FAC86B','2021-06-01 23:37:48.247')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM EmployeeAssignedReviews");
            migrationBuilder.Sql("DELETE FROM Users");
            migrationBuilder.Sql("DELETE FROM Review");
        }
    }
}
