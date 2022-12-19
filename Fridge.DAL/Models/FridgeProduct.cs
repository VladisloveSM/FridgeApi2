using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApi.DAL.Models
{
    public class FridgeProduct
    {
        public Guid Id { get; set; }

        
        public int Quantity { get; set; }

        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }

        public Guid FridgeId { get; set; }

        public virtual Fridge Fridge { get; set; }
    }
}
