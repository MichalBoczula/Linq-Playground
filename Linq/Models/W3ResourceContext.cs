using System;
using Linq.Models.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class W3ResourceContext : DbContext
    {
        public W3ResourceContext()
        {
        }

        public W3ResourceContext(DbContextOptions<W3ResourceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<AffiliatedWith> AffiliatedWith { get; set; }
        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<AsstRefereeMast> AsstRefereeMast { get; set; }
        public virtual DbSet<Block> Block { get; set; }
        public virtual DbSet<CoachMast> CoachMast { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<InventoryCustomer> InventoryCustomer { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Department1> Department1 { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Director> Director { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Employees1> Employees1 { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<GoalDetails> GoalDetails { get; set; }
        public virtual DbSet<JobGrades> JobGrades { get; set; }
        public virtual DbSet<JobHistory> JobHistory { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<MatchCaptain> MatchCaptain { get; set; }
        public virtual DbSet<MatchDetails> MatchDetails { get; set; }
        public virtual DbSet<MatchMast> MatchMast { get; set; }
        public virtual DbSet<Medication> Medication { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieCast> MovieCast { get; set; }
        public virtual DbSet<MovieDirection> MovieDirection { get; set; }
        public virtual DbSet<MovieGenres> MovieGenres { get; set; }
        public virtual DbSet<Nurse> Nurse { get; set; }
        public virtual DbSet<OnCall> OnCall { get; set; }
        public virtual DbSet<InventoryOrders> InventoryOrders { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<PenaltyGk> PenaltyGk { get; set; }
        public virtual DbSet<PenaltyShootout> PenaltyShootout { get; set; }
        public virtual DbSet<Physician> Physician { get; set; }
        public virtual DbSet<PlayerBooked> PlayerBooked { get; set; }
        public virtual DbSet<PlayerInOut> PlayerInOut { get; set; }
        public virtual DbSet<PlayerMast> PlayerMast { get; set; }
        public virtual DbSet<PlayingPosition> PlayingPosition { get; set; }
        public virtual DbSet<Prescribes> Prescribes { get; set; }
        public virtual DbSet<Procedures> Procedures { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<RefereeMast> RefereeMast { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<Reviewer> Reviewer { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<SalaryGrade> SalaryGrade { get; set; }
        public virtual DbSet<InventorySalesman> InventorySalesman { get; set; }
        public virtual DbSet<SoccerCity> SoccerCity { get; set; }
        public virtual DbSet<SoccerCountry> SoccerCountry { get; set; }
        public virtual DbSet<SoccerTeam> SoccerTeam { get; set; }
        public virtual DbSet<SoccerVenue> SoccerVenue { get; set; }
        public virtual DbSet<Stay> Stay { get; set; }
        public virtual DbSet<TeamCoaches> TeamCoaches { get; set; }
        public virtual DbSet<TrainedIn> TrainedIn { get; set; }
        public virtual DbSet<Undergoes> Undergoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=W3Resource;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Actor", "Movies");

                entity.Property(e => e.ActFname)
                    .HasColumnName("act_fname")
                    .HasMaxLength(20);

                entity.Property(e => e.ActGender)
                    .HasColumnName("act_gender")
                    .HasMaxLength(1);

                entity.Property(e => e.ActId).HasColumnName("act_id");

                entity.Property(e => e.ActLname)
                    .HasColumnName("act_lname")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<AffiliatedWith>(entity =>
            {
                entity.HasKey(e => new { e.Physician, e.Department })
                    .HasName("PK__Affiliat__82B9208A3D327DB9");

                entity.ToTable("Affiliated_With", "Hospital");

                entity.Property(e => e.Physician).HasColumnName("physician");

                entity.Property(e => e.Department).HasColumnName("department");

                entity.Property(e => e.Primaryaffiliation).HasColumnName("primaryaffiliation");

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.AffiliatedWith)
                    .HasForeignKey(d => d.Department)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Affiliated_With_Department");

                entity.HasOne(d => d.PhysicianNavigation)
                    .WithMany(p => p.AffiliatedWith)
                    .HasForeignKey(d => d.Physician)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Affiliated_With_Physician");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment", "Hospital");

                entity.Property(e => e.Appointmentid)
                    .HasColumnName("appointmentid")
                    .ValueGeneratedNever();

                entity.Property(e => e.EndDtTime)
                    .HasColumnName("end_dt_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Examinationroom).HasColumnName("examinationroom");

                entity.Property(e => e.Patient).HasColumnName("patient");

                entity.Property(e => e.Physician).HasColumnName("physician");

                entity.Property(e => e.Prepnurse).HasColumnName("prepnurse");

                entity.Property(e => e.StartDtTime)
                    .HasColumnName("start_dt_time")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.PatientNavigation)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.Patient)
                    .HasConstraintName("FK_Appointment_Patient");

                entity.HasOne(d => d.PhysicianNavigation)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.Physician)
                    .HasConstraintName("FK_Appointment_Physician");

                entity.HasOne(d => d.PrepnurseNavigation)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.Prepnurse)
                    .HasConstraintName("FK_Appointment_Nurse");
            });

            modelBuilder.Entity<AsstRefereeMast>(entity =>
            {
                entity.HasKey(e => e.AssRefId);

                entity.ToTable("asst_referee_mast", "SOCCER");

                entity.Property(e => e.AssRefId)
                    .HasColumnName("ass_ref_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AssRefName)
                    .HasColumnName("ass_ref_name")
                    .HasMaxLength(40);

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.AsstRefereeMast)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_asst_referee_mast_soccer_country");
            });

            modelBuilder.Entity<Block>(entity =>
            {
                entity.HasKey(e => new { e.Blockfloor, e.Blockcode })
                    .HasName("PK__Block__AA400D3196C1CFB4");

                entity.ToTable("Block", "Hospital");

                entity.Property(e => e.Blockfloor).HasColumnName("blockfloor");

                entity.Property(e => e.Blockcode).HasColumnName("blockcode");
            });

            modelBuilder.Entity<CoachMast>(entity =>
            {
                entity.HasKey(e => e.CoachId);

                entity.ToTable("coach_mast", "SOCCER");

                entity.Property(e => e.CoachId)
                    .HasColumnName("coach_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CoachName)
                    .HasColumnName("coach_name")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.ToTable("Countries", "HR");

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .HasMaxLength(2);

                entity.Property(e => e.CountryName)
                    .HasColumnName("country_name")
                    .HasMaxLength(40);

                entity.Property(e => e.RegionId)
                    .HasColumnName("region_id")
                    .HasColumnType("numeric(10, 0)");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK_Countries_Regions");
            });

            modelBuilder.Entity<InventoryCustomer>(entity =>
            {
                entity.ToTable("Customer", "Inventory");

                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("numeric(5, 0)");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(15);

                entity.Property(e => e.CustName)
                    .HasColumnName("cust_name")
                    .HasMaxLength(30);

                entity.Property(e => e.Grade)
                    .HasColumnName("grade")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.SalesmanId)
                    .HasColumnName("salesman_id")
                    .HasColumnType("numeric(5, 0)");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepId)
                    .HasName("PK_department_1");

                entity.ToTable("department", "Employee");

                entity.Property(e => e.DepId)
                    .HasColumnName("dep_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DepLocation)
                    .HasColumnName("dep_location")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DepName)
                    .HasColumnName("dep_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Department1>(entity =>
            {
                entity.HasKey(e => e.Departmentid);

                entity.ToTable("Department", "Hospital");

                entity.Property(e => e.Departmentid)
                    .HasColumnName("departmentid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Head).HasColumnName("head");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.HasOne(d => d.HeadNavigation)
                    .WithMany(p => p.Department1)
                    .HasForeignKey(d => d.Head)
                    .HasConstraintName("FK_Department_Physician");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.ToTable("Departments", "HR");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasColumnType("numeric(4, 0)");

                entity.Property(e => e.DepartmentName)
                    .HasColumnName("department_name")
                    .HasMaxLength(30);

                entity.Property(e => e.LocationId)
                    .HasColumnName("location_id")
                    .HasColumnType("numeric(4, 0)");

                entity.Property(e => e.ManagerId)
                    .HasColumnName("manager_id")
                    .HasColumnType("numeric(6, 0)");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Departments_Locations");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Director", "Movies");

                entity.Property(e => e.DirFname)
                    .HasColumnName("dir_fname")
                    .HasMaxLength(20);

                entity.Property(e => e.DirId).HasColumnName("dir_id");

                entity.Property(e => e.DirLname)
                    .HasColumnName("dir_lname")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.ToTable("employees", "Employee");

                entity.Property(e => e.EmpId)
                    .HasColumnName("emp_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Commission)
                    .HasColumnName("commission")
                    .HasColumnType("decimal(7, 2)");

                entity.Property(e => e.DepId).HasColumnName("dep_id");

                entity.Property(e => e.EmpName)
                    .HasColumnName("emp_name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.HireDate)
                    .HasColumnName("hire_date")
                    .HasColumnType("date");

                entity.Property(e => e.JobName)
                    .HasColumnName("job_name")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK_employees_department");
            });

            modelBuilder.Entity<Employees1>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK_Employees_1");

                entity.ToTable("Employees", "HR");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.CommissionPct)
                    .HasColumnName("commission_pct")
                    .HasColumnType("numeric(2, 2)");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasColumnType("numeric(4, 0)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(25);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(20);

                entity.Property(e => e.HireDate)
                    .HasColumnName("hire_date")
                    .HasColumnType("date");

                entity.Property(e => e.JobId)
                    .HasColumnName("job_id")
                    .HasMaxLength(10);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(25);

                entity.Property(e => e.ManagerId)
                    .HasColumnName("manager_id")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(20);

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("numeric(8, 2)");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees1)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Employees__depar__18EBB532");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Employees1)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_Employees_Jobs");
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Genres", "Movies");

                entity.Property(e => e.GenId).HasColumnName("gen_id");

                entity.Property(e => e.GenTitle)
                    .HasColumnName("gen_title")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<GoalDetails>(entity =>
            {
                entity.HasKey(e => e.GoalId);

                entity.ToTable("goal_details", "SOCCER");

                entity.Property(e => e.GoalId)
                    .HasColumnName("goal_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.GoalHalf).HasColumnName("goal_half");

                entity.Property(e => e.GoalSchedule)
                    .HasColumnName("goal_schedule")
                    .HasMaxLength(2);

                entity.Property(e => e.GoalTime).HasColumnName("goal_time");

                entity.Property(e => e.GoalType)
                    .HasColumnName("goal_type")
                    .HasMaxLength(1);

                entity.Property(e => e.MatchNo).HasColumnName("match_no");

                entity.Property(e => e.PlayStage)
                    .HasColumnName("play_stage")
                    .HasMaxLength(1);

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.HasOne(d => d.MatchNoNavigation)
                    .WithMany(p => p.GoalDetails)
                    .HasForeignKey(d => d.MatchNo)
                    .HasConstraintName("FK_goal_details_match_mast");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.GoalDetails)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_goal_detailsPlayer");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.GoalDetails)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_goal_details_soccer_team");
            });

            modelBuilder.Entity<JobGrades>(entity =>
            {
                entity.HasKey(e => e.GradeLevel);

                entity.ToTable("Job_Grades", "HR");

                entity.Property(e => e.GradeLevel)
                    .HasColumnName("grade_level")
                    .HasMaxLength(20);

                entity.Property(e => e.HighestSal)
                    .HasColumnName("highest_sal")
                    .HasColumnType("numeric(5, 0)");

                entity.Property(e => e.LowestSal)
                    .HasColumnName("lowest_sal")
                    .HasColumnType("numeric(5, 0)");
            });

            modelBuilder.Entity<JobHistory>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.StartDate });

                entity.ToTable("Job_History", "HR");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasColumnType("numeric(4, 0)");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("date");

                entity.Property(e => e.JobId)
                    .HasColumnName("job_id")
                    .HasMaxLength(10);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.JobHistory)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Job_History_Departments");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.JobHistory)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Job_Histo__emplo__1AD3FDA4");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobHistory)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_Job_History_Jobs");
            });

            modelBuilder.Entity<Jobs>(entity =>
            {
                entity.HasKey(e => e.JobId);

                entity.ToTable("Jobs", "HR");

                entity.Property(e => e.JobId)
                    .HasColumnName("job_id")
                    .HasMaxLength(10);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasColumnName("job_title")
                    .HasMaxLength(35);

                entity.Property(e => e.MaxSalary)
                    .HasColumnName("max_salary")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.MinSalary)
                    .HasColumnName("min_salary")
                    .HasColumnType("numeric(6, 0)");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.ToTable("Locations", "HR");

                entity.Property(e => e.LocationId)
                    .HasColumnName("location_id")
                    .HasColumnType("numeric(4, 0)");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(30);

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .HasMaxLength(2);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postal_code")
                    .HasMaxLength(12);

                entity.Property(e => e.StateProvince)
                    .HasColumnName("state_province")
                    .HasMaxLength(25);

                entity.Property(e => e.StreetAddress)
                    .HasColumnName("street_address")
                    .HasMaxLength(40);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__Locations__count__1DB06A4F");
            });

            modelBuilder.Entity<MatchCaptain>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("match_captain", "SOCCER");

                entity.Property(e => e.MatchNo).HasColumnName("match_no");

                entity.Property(e => e.PlayerCaptain).HasColumnName("player_captain");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.HasOne(d => d.MatchNoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MatchNo)
                    .HasConstraintName("FK_match_captain_match_mast");

                entity.HasOne(d => d.Team)
                    .WithMany()
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_match_captain_soccer_team");
            });

            modelBuilder.Entity<MatchDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("match_details", "SOCCER");

                entity.Property(e => e.AssRef).HasColumnName("ass_ref");

                entity.Property(e => e.DecidedBy)
                    .HasColumnName("decided_by")
                    .HasMaxLength(1);

                entity.Property(e => e.GoalScore).HasColumnName("goal_score");

                entity.Property(e => e.MatchNo).HasColumnName("match_no");

                entity.Property(e => e.PenaltyScore).HasColumnName("penalty_score");

                entity.Property(e => e.PlayStage)
                    .HasColumnName("play_stage")
                    .HasMaxLength(1);

                entity.Property(e => e.PlayerGk).HasColumnName("player_gk");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.WinLose)
                    .HasColumnName("win_lose")
                    .HasMaxLength(1);

                entity.HasOne(d => d.AssRefNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.AssRef)
                    .HasConstraintName("FK_match_details_asst_referee_mast");

                entity.HasOne(d => d.MatchNoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MatchNo)
                    .HasConstraintName("FK_match_details_match_mast");

                entity.HasOne(d => d.Team)
                    .WithMany()
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_match_details_soccer_team");
            });

            modelBuilder.Entity<MatchMast>(entity =>
            {
                entity.HasKey(e => e.MatchNo);

                entity.ToTable("match_mast", "SOCCER");

                entity.Property(e => e.MatchNo)
                    .HasColumnName("match_no")
                    .ValueGeneratedNever();

                entity.Property(e => e.Audience).HasColumnName("audience");

                entity.Property(e => e.DecidedBy)
                    .HasColumnName("decided_by")
                    .HasMaxLength(1);

                entity.Property(e => e.GoalScore)
                    .HasColumnName("goal_score")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PlayDate)
                    .HasColumnName("play_date")
                    .HasColumnType("date");

                entity.Property(e => e.PlayStage)
                    .HasColumnName("play_stage")
                    .HasMaxLength(1);

                entity.Property(e => e.PlrOfMatch).HasColumnName("plr_of_match");

                entity.Property(e => e.RefereeId).HasColumnName("referee_id");

                entity.Property(e => e.Results)
                    .HasColumnName("results")
                    .HasMaxLength(5);

                entity.Property(e => e.Stop1Sec).HasColumnName("stop1_sec");

                entity.Property(e => e.Stop2Sec).HasColumnName("stop2_sec");

                entity.Property(e => e.VenueId).HasColumnName("venue_id");

                entity.HasOne(d => d.Referee)
                    .WithMany(p => p.MatchMast)
                    .HasForeignKey(d => d.RefereeId)
                    .HasConstraintName("FK_match_mast_referee_mast");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.MatchMast)
                    .HasForeignKey(d => d.VenueId)
                    .HasConstraintName("FK_match_mast_soccer_venue");
            });

            modelBuilder.Entity<Medication>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Medication", "Hospital");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .ValueGeneratedNever();

                entity.Property(e => e.Brand).HasColumnName("brand");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Movie", "Movies");

                entity.Property(e => e.MovDtRel)
                    .HasColumnName("mov_dt_rel")
                    .HasColumnType("date");

                entity.Property(e => e.MovId).HasColumnName("mov_id");

                entity.Property(e => e.MovLang)
                    .HasColumnName("mov_lang")
                    .HasMaxLength(15);

                entity.Property(e => e.MovRelCountry)
                    .HasColumnName("mov_rel_country")
                    .HasMaxLength(5);

                entity.Property(e => e.MovTime).HasColumnName("mov_time");

                entity.Property(e => e.MovTitle)
                    .HasColumnName("mov_title")
                    .HasMaxLength(50);

                entity.Property(e => e.MovYear).HasColumnName("mov_year");
            });

            modelBuilder.Entity<MovieCast>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Movie_cast", "Movies");

                entity.Property(e => e.ActId).HasColumnName("act_id");

                entity.Property(e => e.MovId).HasColumnName("mov_id");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<MovieDirection>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Movie_Direction", "Movies");

                entity.Property(e => e.DirId).HasColumnName("dir_id");

                entity.Property(e => e.MovId).HasColumnName("mov_id");
            });

            modelBuilder.Entity<MovieGenres>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Movie_Genres", "Movies");

                entity.Property(e => e.GenId).HasColumnName("gen_id");

                entity.Property(e => e.MovId).HasColumnName("mov_id");
            });

            modelBuilder.Entity<Nurse>(entity =>
            {
                entity.HasKey(e => e.Employeeid);

                entity.ToTable("Nurse", "Hospital");

                entity.Property(e => e.Employeeid)
                    .HasColumnName("employeeid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.Registered).HasColumnName("registered");

                entity.Property(e => e.Ssn).HasColumnName("ssn");
            });

            modelBuilder.Entity<OnCall>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("On-Call", "Hospital");

                entity.Property(e => e.Blockcode).HasColumnName("blockcode");

                entity.Property(e => e.Blockfloor).HasColumnName("blockfloor");

                entity.Property(e => e.Nurse).HasColumnName("nurse");

                entity.Property(e => e.Oncallend)
                    .HasColumnName("oncallend")
                    .HasColumnType("datetime");

                entity.Property(e => e.Oncallstart)
                    .HasColumnName("oncallstart")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.NurseNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Nurse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_On-Call_Nurse");

                entity.HasOne(d => d.Block)
                    .WithMany()
                    .HasForeignKey(d => new { d.Blockfloor, d.Blockcode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OnCall_Block");
            });

            modelBuilder.Entity<InventoryOrders>(entity =>
            {
                entity.HasKey(e => e.OrdNo);

                entity.ToTable("Orders", "Inventory");

                entity.Property(e => e.OrdNo)
                    .HasColumnName("ord_no")
                    .HasColumnType("numeric(5, 0)");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("numeric(5, 0)");

                entity.Property(e => e.OrdDate)
                    .HasColumnName("ord_date")
                    .HasColumnType("date");

                entity.Property(e => e.PurchAmt)
                    .HasColumnName("purch_amt")
                    .HasColumnType("numeric(8, 2)");

                entity.Property(e => e.SalesmanId)
                    .HasColumnName("salesman_id")
                    .HasColumnType("numeric(5, 0)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Orders_Customer");

                entity.HasOne(d => d.Salesman)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.SalesmanId)
                    .HasConstraintName("FK_Orders_Salesman");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Ssn);

                entity.ToTable("Patient", "Hospital");

                entity.Property(e => e.Ssn)
                    .HasColumnName("ssn")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Insuranceid).HasColumnName("insuranceid");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Pcp).HasColumnName("pcp");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.HasOne(d => d.PcpNavigation)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.Pcp)
                    .HasConstraintName("FK_Patient_Physician");
            });

            modelBuilder.Entity<PenaltyGk>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("penalty_gk", "SOCCER");

                entity.Property(e => e.MatchNo).HasColumnName("match_no");

                entity.Property(e => e.PlayerGk).HasColumnName("player_gk");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.HasOne(d => d.MatchNoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MatchNo)
                    .HasConstraintName("FK_penalty_gk_match_mast");

                entity.HasOne(d => d.Team)
                    .WithMany()
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_penalty_gk_soccer_team");
            });

            modelBuilder.Entity<PenaltyShootout>(entity =>
            {
                entity.HasKey(e => e.KickId);

                entity.ToTable("penalty_shootout", "SOCCER");

                entity.Property(e => e.KickId)
                    .HasColumnName("kick_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.KickNo).HasColumnName("kick_no");

                entity.Property(e => e.MatchNo).HasColumnName("match_no");

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.Property(e => e.ScoreGoal)
                    .HasColumnName("score_goal")
                    .HasMaxLength(1);

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.HasOne(d => d.MatchNoNavigation)
                    .WithMany(p => p.PenaltyShootout)
                    .HasForeignKey(d => d.MatchNo)
                    .HasConstraintName("FK_penalty_shootout_match_mast");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PenaltyShootout)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_penalty_shootoutPlayer");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.PenaltyShootout)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_penalty_shootout_soccer_team");
            });

            modelBuilder.Entity<Physician>(entity =>
            {
                entity.HasKey(e => e.Employeeid);

                entity.ToTable("Physician", "Hospital");

                entity.Property(e => e.Employeeid)
                    .HasColumnName("employeeid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.Ssn).HasColumnName("ssn");
            });

            modelBuilder.Entity<PlayerBooked>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("player_booked", "SOCCER");

                entity.Property(e => e.BookingTime).HasColumnName("booking_time");

                entity.Property(e => e.MatchNo).HasColumnName("match_no");

                entity.Property(e => e.PlayHalf).HasColumnName("play_half");

                entity.Property(e => e.PlaySchedule)
                    .HasColumnName("play_schedule")
                    .HasMaxLength(2);

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.Property(e => e.SentOff)
                    .HasColumnName("sent_off")
                    .HasMaxLength(1);

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.HasOne(d => d.MatchNoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MatchNo)
                    .HasConstraintName("FK_player_booked_match_mast");

                entity.HasOne(d => d.Player)
                    .WithMany()
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_player_bookedPlayer");
            });

            modelBuilder.Entity<PlayerInOut>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("player_in_out", "SOCCER");

                entity.Property(e => e.InOut)
                    .HasColumnName("in_out")
                    .HasMaxLength(1);

                entity.Property(e => e.MatchNo).HasColumnName("match_no");

                entity.Property(e => e.PlayHalf).HasColumnName("play_half");

                entity.Property(e => e.PlaySchedule)
                    .HasColumnName("play_schedule")
                    .HasMaxLength(2);

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.TimeInOut).HasColumnName("time_in_out");

                entity.HasOne(d => d.MatchNoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MatchNo)
                    .HasConstraintName("FK_player_in_out_match_mast");

                entity.HasOne(d => d.Player)
                    .WithMany()
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_player_in_outPlayer");

                entity.HasOne(d => d.Team)
                    .WithMany()
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_player_in_out_soccer_team");
            });

            modelBuilder.Entity<PlayerMast>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.ToTable("player_mast", "SOCCER");

                entity.Property(e => e.PlayerId)
                    .HasColumnName("player_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.DtOfBir)
                    .HasColumnName("dt_of_bir")
                    .HasColumnType("date");

                entity.Property(e => e.JerseyNo).HasColumnName("jersey_no");

                entity.Property(e => e.PlayerName)
                    .HasColumnName("player_name")
                    .HasMaxLength(40);

                entity.Property(e => e.PlayingClub)
                    .HasColumnName("playing_club")
                    .HasMaxLength(40);

                entity.Property(e => e.PosiToPlay)
                    .HasColumnName("posi_to_play")
                    .HasMaxLength(2);

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.HasOne(d => d.PosiToPlayNavigation)
                    .WithMany(p => p.PlayerMast)
                    .HasForeignKey(d => d.PosiToPlay)
                    .HasConstraintName("FK_player_mast_playing_position");
            });

            modelBuilder.Entity<PlayingPosition>(entity =>
            {
                entity.HasKey(e => e.PositionId);

                entity.ToTable("playing_position", "SOCCER");

                entity.Property(e => e.PositionId)
                    .HasColumnName("position_id")
                    .HasMaxLength(2);

                entity.Property(e => e.PositionDesc)
                    .HasColumnName("position_desc")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Prescribes>(entity =>
            {
                entity.HasKey(e => new { e.Physician, e.Patient, e.Medication, e.Date })
                    .HasName("PK__Prescrib__2CED93CB1F2B9CEA");

                entity.ToTable("Prescribes", "Hospital");

                entity.Property(e => e.Physician).HasColumnName("physician");

                entity.Property(e => e.Patient).HasColumnName("patient");

                entity.Property(e => e.Medication).HasColumnName("medication");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Appointment).HasColumnName("appointment");

                entity.Property(e => e.Dose).HasColumnName("dose");

                entity.HasOne(d => d.AppointmentNavigation)
                    .WithMany(p => p.Prescribes)
                    .HasForeignKey(d => d.Appointment)
                    .HasConstraintName("FK_Prescribes_Appointment");

                entity.HasOne(d => d.MedicationNavigation)
                    .WithMany(p => p.Prescribes)
                    .HasForeignKey(d => d.Medication)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prescribes_Medication");

                entity.HasOne(d => d.PatientNavigation)
                    .WithMany(p => p.Prescribes)
                    .HasForeignKey(d => d.Patient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prescribes_Patient");

                entity.HasOne(d => d.PhysicianNavigation)
                    .WithMany(p => p.Prescribes)
                    .HasForeignKey(d => d.Physician)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prescribes_Physician");
            });

            modelBuilder.Entity<Procedures>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Procedures", "Hospital");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Rating", "Movies");

                entity.Property(e => e.MovId).HasColumnName("mov_id");

                entity.Property(e => e.NumORatings).HasColumnName("num_o_ratings");

                entity.Property(e => e.RevId).HasColumnName("rev_id");

                entity.Property(e => e.RevStars)
                    .HasColumnName("rev_stars")
                    .HasColumnType("numeric(4, 2)");
            });

            modelBuilder.Entity<RefereeMast>(entity =>
            {
                entity.HasKey(e => e.RefereeId);

                entity.ToTable("referee_mast", "SOCCER");

                entity.Property(e => e.RefereeId)
                    .HasColumnName("referee_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.RefereeName)
                    .HasColumnName("referee_name")
                    .HasMaxLength(40);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.RefereeMast)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_referee_mast_soccer_country");
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.HasKey(e => e.RegionId);

                entity.ToTable("Regions", "HR");

                entity.Property(e => e.RegionId)
                    .HasColumnName("region_id")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.RegionName)
                    .HasColumnName("region_name")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Reviewer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Reviewer", "Movies");

                entity.Property(e => e.RevId).HasColumnName("rev_id");

                entity.Property(e => e.RevName)
                    .HasColumnName("rev_name")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.Roomnumber);

                entity.ToTable("Room", "Hospital");

                entity.Property(e => e.Roomnumber)
                    .HasColumnName("roomnumber")
                    .ValueGeneratedNever();

                entity.Property(e => e.Blockcode).HasColumnName("blockcode");

                entity.Property(e => e.Blockfloor).HasColumnName("blockfloor");

                entity.Property(e => e.Roomtype)
                    .HasColumnName("roomtype")
                    .HasMaxLength(30);

                entity.Property(e => e.Unavailable).HasColumnName("unavailable");

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => new { d.Blockfloor, d.Blockcode })
                    .HasConstraintName("fk_Room_Block");
            });

            modelBuilder.Entity<SalaryGrade>(entity =>
            {
                entity.HasKey(e => e.Grade);

                entity.ToTable("salary_grade", "Employee");

                entity.Property(e => e.Grade).HasColumnName("grade");

                entity.Property(e => e.MaxSalary).HasColumnName("max_salary");

                entity.Property(e => e.MinSalary).HasColumnName("min_salary");
            });

            modelBuilder.Entity<InventorySalesman>(entity =>
            {
                entity.ToTable("Salesman", "Inventory");

                entity.HasKey(e => e.SalesmanId);

                entity.Property(e => e.SalesmanId)
                    .HasColumnName("salesman_id")
                    .HasColumnType("numeric(5, 0)");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(15);

                entity.Property(e => e.Commission)
                    .HasColumnName("commission")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<SoccerCity>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("soccer_city", "SOCCER");

                entity.Property(e => e.CityId)
                    .HasColumnName("city_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(25);

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.SoccerCity)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_soccer_city_soccer_country");
            });

            modelBuilder.Entity<SoccerCountry>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.ToTable("soccer_country", "SOCCER");

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryAbbr)
                    .HasColumnName("country_abbr")
                    .HasMaxLength(4);

                entity.Property(e => e.CountryName)
                    .HasColumnName("country_name")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<SoccerTeam>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.ToTable("soccer_team", "SOCCER");

                entity.Property(e => e.TeamId)
                    .HasColumnName("team_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Draw).HasColumnName("draw");

                entity.Property(e => e.GoalAgnst).HasColumnName("goal_agnst");

                entity.Property(e => e.GoalDiff).HasColumnName("goal_diff");

                entity.Property(e => e.GoalFor).HasColumnName("goal_for");

                entity.Property(e => e.GroupPosition).HasColumnName("group_position");

                entity.Property(e => e.Lost).HasColumnName("lost");

                entity.Property(e => e.MatchPlayed).HasColumnName("match_played");

                entity.Property(e => e.Points).HasColumnName("points");

                entity.Property(e => e.TeamGroup)
                    .HasColumnName("team_group")
                    .HasMaxLength(1);

                entity.Property(e => e.Won).HasColumnName("won");
            });

            modelBuilder.Entity<SoccerVenue>(entity =>
            {
                entity.HasKey(e => e.VenueId);

                entity.ToTable("soccer_venue", "SOCCER");

                entity.Property(e => e.VenueId)
                    .HasColumnName("venue_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AudCapacity).HasColumnName("aud_capacity");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.VenueName)
                    .HasColumnName("venue_name")
                    .HasMaxLength(30);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.SoccerVenue)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_soccer_venue_soccer_city");
            });

            modelBuilder.Entity<Stay>(entity =>
            {
                entity.ToTable("Stay", "Hospital");

                entity.Property(e => e.Stayid)
                    .HasColumnName("stayid")
                    .ValueGeneratedNever();

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Patient).HasColumnName("patient");

                entity.Property(e => e.Room).HasColumnName("room");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.PatientNavigation)
                    .WithMany(p => p.Stay)
                    .HasForeignKey(d => d.Patient)
                    .HasConstraintName("FK_Stay_Patient");

                entity.HasOne(d => d.RoomNavigation)
                    .WithMany(p => p.Stay)
                    .HasForeignKey(d => d.Room)
                    .HasConstraintName("FK_Stay_Room");
            });

            modelBuilder.Entity<TeamCoaches>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("team_coaches", "SOCCER");

                entity.Property(e => e.CoachId).HasColumnName("coach_id");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.HasOne(d => d.Coach)
                    .WithMany()
                    .HasForeignKey(d => d.CoachId)
                    .HasConstraintName("FK_team_coaches_coach_mast");

                entity.HasOne(d => d.Team)
                    .WithMany()
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_team_coaches_soccer_team");
            });

            modelBuilder.Entity<TrainedIn>(entity =>
            {
                entity.HasKey(e => new { e.Physician, e.Treatment })
                    .HasName("PK__Trained___9E42192E2FC97BA5");

                entity.ToTable("Trained_in", "Hospital");

                entity.Property(e => e.Physician).HasColumnName("physician");

                entity.Property(e => e.Treatment).HasColumnName("treatment");

                entity.Property(e => e.Certificationdate)
                    .HasColumnName("certificationdate")
                    .HasColumnType("date");

                entity.Property(e => e.Certificationexpires)
                    .HasColumnName("certificationexpires")
                    .HasColumnType("date");

                entity.HasOne(d => d.PhysicianNavigation)
                    .WithMany(p => p.TrainedIn)
                    .HasForeignKey(d => d.Physician)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trained_in_Physician");

                entity.HasOne(d => d.TreatmentNavigation)
                    .WithMany(p => p.TrainedIn)
                    .HasForeignKey(d => d.Treatment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trained_in_Procedures");
            });

            modelBuilder.Entity<Undergoes>(entity =>
            {
                entity.HasKey(e => new { e.Patient, e.Procedure, e.Stay, e.Date })
                    .HasName("PK__Undergoe__296B7898CFAF34AD");

                entity.ToTable("Undergoes", "Hospital");

                entity.Property(e => e.Patient).HasColumnName("patient");

                entity.Property(e => e.Procedure).HasColumnName("procedure");

                entity.Property(e => e.Stay).HasColumnName("stay");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Assistingnurse).HasColumnName("assistingnurse");

                entity.Property(e => e.Physician).HasColumnName("physician");

                entity.HasOne(d => d.AssistingnurseNavigation)
                    .WithMany(p => p.Undergoes)
                    .HasForeignKey(d => d.Assistingnurse)
                    .HasConstraintName("FK_Undergoes_Nurse");

                entity.HasOne(d => d.PatientNavigation)
                    .WithMany(p => p.Undergoes)
                    .HasForeignKey(d => d.Patient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Undergoes_Patient");

                entity.HasOne(d => d.PhysicianNavigation)
                    .WithMany(p => p.Undergoes)
                    .HasForeignKey(d => d.Physician)
                    .HasConstraintName("FK_Undergoes_Physician");

                entity.HasOne(d => d.ProcedureNavigation)
                    .WithMany(p => p.Undergoes)
                    .HasForeignKey(d => d.Procedure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Undergoes_Procedures");

                entity.HasOne(d => d.StayNavigation)
                    .WithMany(p => p.Undergoes)
                    .HasForeignKey(d => d.Stay)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Undergoes_Stay");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
