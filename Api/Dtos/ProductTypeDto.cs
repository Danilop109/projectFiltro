using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Api.Dtos
{
    public class ProductTypeDto : BaseEntity2
    {
        public string DescriptionText { get; set; }
        public string DescriptionHtml { get; set; }
        public string Image { get; set; }

    }
}