// <auto-generated />
using Endpoint;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Endpoint.Migrations
{
    [DbContext(typeof(CSVContext))]
    partial class CSVContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("Endpoint.CSVRecord", b =>
                {
                    b.Property<int>("CSVRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountNumber")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Reference")
                        .HasColumnType("TEXT");

                    b.Property<int>("SortCode")
                        .HasColumnType("INTEGER");

                    b.HasKey("CSVRecordId");

                    b.ToTable("CSVRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
