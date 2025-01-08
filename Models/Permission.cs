using System.ComponentModel.DataAnnotations.Schema;

namespace OrderService.Models
{
    public class Permission : BaseModel
    {
        public string Name { get; set; }

        [Index(IsUnique = true)]
        public string Key { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}