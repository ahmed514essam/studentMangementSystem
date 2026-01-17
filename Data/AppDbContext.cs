using Microsoft.EntityFrameworkCore;
using studentMangementSystem.Models;

namespace studentMangementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<StudyYear> StudyYears { get; set; }

        public DbSet<DepartmentStudyYear> DepartmentStudyYears { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Admin> Admin  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
modelBuilder.HasSequence<int>("DeliveryOrder").StartsAt(1000).IncrementsBy(1);
            var students = modelBuilder.Entity<Student>();
            students.HasKey(s => s.Id);
            students.HasOne(s => s.Department)
                    .WithMany(d => d.Students)
                    .HasForeignKey(s => s.DepartmentId);
            students.HasOne(s => s.StudyYear)
                    .WithMany(sy => sy.Students)
                    .HasForeignKey(s => s.StudyYearId);
            students.HasOne(s => s.Sport)
                    .WithMany(sp => sp.Students)
                    .HasForeignKey(s => s.SportId);
            students.HasOne(s => s.Status)
                    .WithMany(st => st.Students)
                    .HasForeignKey(s => s.StatusId);
            students.Property(o => o.InrollDate).HasDefaultValueSql("GETDATE()");
            students.Property(o => o.Name).IsRequired().HasMaxLength(300);
            students.Property(o => o.Email).IsRequired().HasMaxLength(300);
            students.Property(o => o.Address).IsRequired().HasMaxLength(500);
            students.Property(o => o.PhoneNumber).IsRequired().HasMaxLength(11);
            students.Property(s => s.DeliveryOrder).HasDefaultValueSql("NEXT VALUE FOR DeliveryOrder");


            var subjects = modelBuilder.Entity<Subject>();
            subjects.HasKey(s => s.Id);
            subjects.HasOne(s => s.Department)
                    .WithMany(d => d.Subjects)
                    .HasForeignKey(s => s.DepartmentId);
            subjects.HasOne(s => s.StudyYear)
                    .WithMany(sy => sy.Subjects)
                    .HasForeignKey(s => s.StudyYearId);
            subjects.Property(o => o.Name).IsRequired().HasMaxLength(300);
            subjects.Property(o => o.SubjectDoctor).IsRequired().HasMaxLength(300);
            subjects.Property(o => o.CreditHours).IsRequired();
            subjects.Property(s => s.DeliveryOrder).HasDefaultValueSql("NEXT VALUE FOR DeliveryOrder");


            var studentSubjects = modelBuilder.Entity<StudentSubject>();
            studentSubjects.HasKey(ss => new { ss.StudentId, ss.SubjectId });
            studentSubjects.HasOne(st => st.Student)
                .WithMany(st => st.StudentSubjects)
                .HasForeignKey(st => st.StudentId);
            studentSubjects.HasOne(su => su.Subject)
                .WithMany(su => su.StudentSubjects)
                .HasForeignKey(su => su.SubjectId);
            studentSubjects.Property(sb => sb.TotalMarks).HasColumnType("decimal(5,2)");

            var departmentStudyYears = modelBuilder.Entity<DepartmentStudyYear>();
            departmentStudyYears.HasKey(dsy => new { dsy.DepartmentId, dsy.StudyYearId });
departmentStudyYears.HasOne(x => x.Department).WithMany(x => x.DepartmentStudyYears).HasForeignKey(x => x.DepartmentId);
            departmentStudyYears.HasOne(x => x.StudyYear).WithMany(x => x.DepartmentStudyYears).HasForeignKey(x => x.StudyYearId);



            var departments = modelBuilder.Entity<Department>();
            departments.HasKey(d => d.Id);
            departments.Property(o => o.Name).IsRequired().HasMaxLength(300);
            departments.Property(o => o.DepartmentHead).IsRequired().HasMaxLength(300);
            departments.HasMany(d => d.Students)
                       .WithOne(s => s.Department)
                       .HasForeignKey(s => s.DepartmentId);
            departments.HasMany(d => d.Subjects)
                          .WithOne(s => s.Department)
                          .HasForeignKey(s => s.DepartmentId);
            //departments.HasMany(d => d.StudyYears)
            //                .WithOne(sy => sy.Department)
            //                .HasForeignKey(sy => sy.DepartmentId);
            departments.Property(s => s.DeliveryOrder).HasDefaultValueSql("NEXT VALUE FOR DeliveryOrder");

            departments.HasData(
                new Department {Id = 1 , Name = "Mechanical Engineering" , DepartmentHead = "Oliver Herston"  },
                new Department { Id = 2, Name = "Electrical Engineering", DepartmentHead = "Mike Hary" },
                new Department { Id = 3, Name = "Civil Engineering ", DepartmentHead = "Steven Odegard" },
                new Department { Id = 4, Name = "Computer Science", DepartmentHead = "Jordon Harmi" },
                new Department { Id = 5, Name = "Management Information Systems", DepartmentHead = "Alina Foc" },
                new Department { Id = 6, Name = "Information technology", DepartmentHead = "Zendaia " },
                new Department { Id = 7, Name = "business management", DepartmentHead = "Sedeny Foler" },
                new Department { Id = 8, Name = "Fine Arts", DepartmentHead = "Hary Tormy" },
                new Department { Id = 9, Name = "Law", DepartmentHead = "Tom Armorstrong" },
                new Department { Id = 10, Name = "Primary Education", DepartmentHead = "Keny Ackremany" }

                );



            var sports = modelBuilder.Entity<Sport>();
            sports.HasKey(o => o.Id);
            sports.Property(o => o.Name).IsRequired().HasMaxLength(300);
            sports.Property(o => o.Coach).IsRequired().HasMaxLength(300);
            sports.HasMany(s => s.Students)
                  .WithOne(st => st.Sport)
                  .HasForeignKey(st => st.SportId);
            sports.Property(s => s.DeliveryOrder).HasDefaultValueSql("NEXT VALUE FOR DeliveryOrder");
            sports.HasData(
                new Sport { Id = 1, Name = "Football", Coach = "John Doe" },
                new Sport { Id = 2, Name = "Basketball", Coach = "Jane Smith" },
                new Sport { Id = 3, Name = "Tennis", Coach = "Mike Johnson" }
                );

            var statuses = modelBuilder.Entity<Status>();
            statuses.HasKey(o => o.Id);
            statuses.Property(o => o.Name).IsRequired().HasMaxLength(300);
            statuses.HasMany(s => s.Students)
                    .WithOne(st => st.Status)
                    .HasForeignKey(st => st.StatusId);
            statuses.HasData(
                new Status { Id = 1, Name = "Successful" },
                new Status { Id = 2, Name = "Failed" },
                new Status { Id = 3, Name = "Graduated" }
                );

            var studyYears = modelBuilder.Entity<StudyYear>();
            studyYears.HasKey(o => o.Id);
            studyYears.Property(o => o.Name).IsRequired().HasMaxLength(100);
            studyYears.HasMany(sy => sy.Students)
                      .WithOne(s => s.StudyYear)
                      .HasForeignKey(s => s.StudyYearId);
            studyYears.HasMany(sy => sy.Subjects)
                        .WithOne(s => s.StudyYear)
                        .HasForeignKey(s => s.StudyYearId);
            //studyYears.HasOne(sy => sy.Department)
            //           .WithMany(d => d.StudyYears)
            //           .HasForeignKey(sy => sy.DepartmentId);
            studyYears.HasData(
                new StudyYear { Id = 1, Name = "Preparatory Engineering" },
                new StudyYear { Id = 2, Name = "First Year"  },
                new StudyYear { Id = 3, Name = "Second Year" },
                new StudyYear { Id = 4, Name = "Third Year" },
                new StudyYear { Id = 5, Name = "Fourth Year" }
                );




            foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                relation.DeleteBehavior = DeleteBehavior.Restrict;
            }



        }


    }
}
