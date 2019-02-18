using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetGram.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    PostID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ID", "Author", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, "Sally", "Flavored Latte with a pretty little swirleydoo", "igmru.com/asdf", "Best Ever Coffee Pic" },
                    { 2, "Bob The Doggo Owner", "We were worried hey might eat them but Max has happily adopted this horde of super-fluffy baby chicks and also kittens!!!!", "igmru.com/KYUTEAF", "MY DOG IS THE CUTEST" },
                    { 3, "Maybe I'M Banksy and forgot?!?", "Work of art! So subversive! Banksy Original?!?", "igmru/TRUEART", "Sweet Graffiti Someone Painted On My Car" },
                    { 4, "Sally's Cool Older Sister", "No really, I put a lot of thought into this. I am very cautious about getting tattoos and I am following my genuine passion for body modifications.", "igmru/SuperSickTat", "Tattoo That I Do Not In Any Way, Shape or Form Regret" },
                    { 5, "Guy who actually really cares about food and/or my dad", "**Insert Cliche Satire of Instagram Food Pics", "igmru/ALovelyDinner", "Picture of Food You're Not Eating!" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "Author", "Content", "PostID" },
                values: new object[] { 1, "Sally", "Wow. So proud of your conviction and style, sis! You are the coolest!", 4 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "Author", "Content", "PostID" },
                values: new object[] { 2, "Bob the Doggo Owner", "Nice! Going to have to try and recreate this for Max. Substituting in kibble, of course!", 5 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "Author", "Content", "PostID" },
                values: new object[] { 3, "Sally's Cool Older Sister", "I just made a gluten-free version of this dish for my friend Amanda, who is also Totally Cool.", 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostID",
                table: "Comments",
                column: "PostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
