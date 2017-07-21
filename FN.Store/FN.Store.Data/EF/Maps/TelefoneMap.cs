using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Data.EF.Maps
{
    internal class TelefoneMap:EntityTypeConfiguration<Telefone>
    {
        public TelefoneMap()
        {
            //Tabela
            ToTable("Tel");

            //PK
            HasKey(k => k.Id);

            //Campos
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Numero).HasColumnType("varchar").HasMaxLength(11).IsRequired();
            Property(c => c.ClienteId).HasColumnType("int");


            //FK
            //http://www.entityframeworktutorial.net/
            HasRequired(c => c.Cliente).WithMany(c => c.Telefones).HasForeignKey(c => c.ClienteId);
        }
    }
}
