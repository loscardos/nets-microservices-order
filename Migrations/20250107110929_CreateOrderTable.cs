using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderService.Migrations
{
    /// <inheritdoc />
    public partial class CreateOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "orders",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                product_name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                quantity = table.Column<int>(nullable: false),
                status = table.Column<string>(maxLength: 50, nullable: false),
                user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_orders", x => x.id);
                table.ForeignKey(
                    name: "fk_orders_users_user_id",
                    column: x => x.user_id,
                    principalTable: "users",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });
            
            migrationBuilder.CreateIndex(
                name: "ix_orders_user_id",
                table: "orders",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "orders");
        }
    }
}
