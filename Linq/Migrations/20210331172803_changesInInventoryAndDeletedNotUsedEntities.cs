using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Linq.Migrations
{
    public partial class changesInInventoryAndDeletedNotUsedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Movies");

            migrationBuilder.EnsureSchema(
                name: "Hospital");

            migrationBuilder.EnsureSchema(
                name: "SOCCER");

            migrationBuilder.EnsureSchema(
                name: "HR");

            migrationBuilder.EnsureSchema(
                name: "Inventory");

            migrationBuilder.EnsureSchema(
                name: "Employee");

            migrationBuilder.CreateTable(
                name: "department",
                schema: "Employee",
                columns: table => new
                {
                    dep_id = table.Column<int>(nullable: false),
                    dep_name = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    dep_location = table.Column<string>(unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department_1", x => x.dep_id);
                });

            migrationBuilder.CreateTable(
                name: "salary_grade",
                schema: "Employee",
                columns: table => new
                {
                    grade = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    min_salary = table.Column<int>(nullable: true),
                    max_salary = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salary_grade", x => x.grade);
                });

            migrationBuilder.CreateTable(
                name: "Block",
                schema: "Hospital",
                columns: table => new
                {
                    blockfloor = table.Column<int>(nullable: false),
                    blockcode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Block__AA400D3196C1CFB4", x => new { x.blockfloor, x.blockcode });
                });

            migrationBuilder.CreateTable(
                name: "Medication",
                schema: "Hospital",
                columns: table => new
                {
                    code = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    brand = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Nurse",
                schema: "Hospital",
                columns: table => new
                {
                    employeeid = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    position = table.Column<string>(nullable: true),
                    registered = table.Column<bool>(nullable: true),
                    ssn = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurse", x => x.employeeid);
                });

            migrationBuilder.CreateTable(
                name: "Physician",
                schema: "Hospital",
                columns: table => new
                {
                    employeeid = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    position = table.Column<string>(nullable: true),
                    ssn = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Physician", x => x.employeeid);
                });

            migrationBuilder.CreateTable(
                name: "Procedures",
                schema: "Hospital",
                columns: table => new
                {
                    code = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    cost = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Job_Grades",
                schema: "HR",
                columns: table => new
                {
                    grade_level = table.Column<string>(maxLength: 20, nullable: false),
                    lowest_sal = table.Column<decimal>(type: "numeric(5, 0)", nullable: true),
                    highest_sal = table.Column<decimal>(type: "numeric(5, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job_Grades", x => x.grade_level);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                schema: "HR",
                columns: table => new
                {
                    job_id = table.Column<string>(maxLength: 10, nullable: false),
                    job_title = table.Column<string>(maxLength: 35, nullable: false),
                    min_salary = table.Column<decimal>(type: "numeric(6, 0)", nullable: true),
                    max_salary = table.Column<decimal>(type: "numeric(6, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.job_id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                schema: "HR",
                columns: table => new
                {
                    region_id = table.Column<decimal>(type: "numeric(10, 0)", nullable: false),
                    region_name = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.region_id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Inventory",
                columns: table => new
                {
                    customer_id = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    salesman_id = table.Column<decimal>(type: "numeric(5, 0)", nullable: true),
                    cust_name = table.Column<string>(maxLength: 30, nullable: true),
                    city = table.Column<string>(maxLength: 15, nullable: true),
                    grade = table.Column<decimal>(type: "numeric(3, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "Salesman",
                schema: "Inventory",
                columns: table => new
                {
                    salesman_id = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    name = table.Column<string>(maxLength: 30, nullable: true),
                    city = table.Column<string>(maxLength: 15, nullable: true),
                    commission = table.Column<decimal>(type: "numeric(5, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salesman", x => x.salesman_id);
                });

            migrationBuilder.CreateTable(
                name: "Actor",
                schema: "Movies",
                columns: table => new
                {
                    act_id = table.Column<int>(nullable: true),
                    act_fname = table.Column<string>(maxLength: 20, nullable: true),
                    act_lname = table.Column<string>(maxLength: 20, nullable: true),
                    act_gender = table.Column<string>(maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Director",
                schema: "Movies",
                columns: table => new
                {
                    dir_id = table.Column<int>(nullable: true),
                    dir_fname = table.Column<string>(maxLength: 20, nullable: true),
                    dir_lname = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                schema: "Movies",
                columns: table => new
                {
                    gen_id = table.Column<int>(nullable: true),
                    gen_title = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                schema: "Movies",
                columns: table => new
                {
                    mov_id = table.Column<int>(nullable: true),
                    mov_title = table.Column<string>(maxLength: 50, nullable: true),
                    mov_year = table.Column<int>(nullable: true),
                    mov_time = table.Column<int>(nullable: true),
                    mov_lang = table.Column<string>(maxLength: 15, nullable: true),
                    mov_dt_rel = table.Column<DateTime>(type: "date", nullable: true),
                    mov_rel_country = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Movie_cast",
                schema: "Movies",
                columns: table => new
                {
                    mov_id = table.Column<int>(nullable: true),
                    act_id = table.Column<int>(nullable: true),
                    role = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Movie_Direction",
                schema: "Movies",
                columns: table => new
                {
                    mov_id = table.Column<int>(nullable: true),
                    dir_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Movie_Genres",
                schema: "Movies",
                columns: table => new
                {
                    mov_id = table.Column<int>(nullable: true),
                    gen_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                schema: "Movies",
                columns: table => new
                {
                    mov_id = table.Column<int>(nullable: true),
                    rev_id = table.Column<int>(nullable: true),
                    rev_stars = table.Column<decimal>(type: "numeric(4, 2)", nullable: true),
                    num_o_ratings = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Reviewer",
                schema: "Movies",
                columns: table => new
                {
                    rev_id = table.Column<int>(nullable: true),
                    rev_name = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "coach_mast",
                schema: "SOCCER",
                columns: table => new
                {
                    coach_id = table.Column<int>(nullable: false),
                    coach_name = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coach_mast", x => x.coach_id);
                });

            migrationBuilder.CreateTable(
                name: "playing_position",
                schema: "SOCCER",
                columns: table => new
                {
                    position_id = table.Column<string>(maxLength: 2, nullable: false),
                    position_desc = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playing_position", x => x.position_id);
                });

            migrationBuilder.CreateTable(
                name: "soccer_country",
                schema: "SOCCER",
                columns: table => new
                {
                    country_id = table.Column<int>(nullable: false),
                    country_abbr = table.Column<string>(maxLength: 4, nullable: true),
                    country_name = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_soccer_country", x => x.country_id);
                });

            migrationBuilder.CreateTable(
                name: "soccer_team",
                schema: "SOCCER",
                columns: table => new
                {
                    team_id = table.Column<int>(nullable: false),
                    team_group = table.Column<string>(maxLength: 1, nullable: true),
                    match_played = table.Column<int>(nullable: true),
                    won = table.Column<int>(nullable: true),
                    draw = table.Column<int>(nullable: true),
                    lost = table.Column<int>(nullable: true),
                    goal_for = table.Column<int>(nullable: true),
                    goal_agnst = table.Column<int>(nullable: true),
                    goal_diff = table.Column<int>(nullable: true),
                    points = table.Column<int>(nullable: true),
                    group_position = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_soccer_team", x => x.team_id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                schema: "Employee",
                columns: table => new
                {
                    emp_id = table.Column<int>(nullable: false),
                    emp_name = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    job_name = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    manager_id = table.Column<int>(nullable: true),
                    hire_date = table.Column<DateTime>(type: "date", nullable: true),
                    salary = table.Column<decimal>(type: "decimal(10, 2)", nullable: true),
                    commission = table.Column<decimal>(type: "decimal(7, 2)", nullable: true),
                    dep_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.emp_id);
                    table.ForeignKey(
                        name: "FK_employees_department",
                        column: x => x.dep_id,
                        principalSchema: "Employee",
                        principalTable: "department",
                        principalColumn: "dep_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                schema: "Hospital",
                columns: table => new
                {
                    roomnumber = table.Column<int>(nullable: false),
                    blockfloor = table.Column<int>(nullable: true),
                    blockcode = table.Column<int>(nullable: true),
                    roomtype = table.Column<string>(maxLength: 30, nullable: true),
                    unavailable = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.roomnumber);
                    table.ForeignKey(
                        name: "fk_Room_Block",
                        columns: x => new { x.blockfloor, x.blockcode },
                        principalSchema: "Hospital",
                        principalTable: "Block",
                        principalColumns: new[] { "blockfloor", "blockcode" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "On-Call",
                schema: "Hospital",
                columns: table => new
                {
                    nurse = table.Column<int>(nullable: false),
                    blockfloor = table.Column<int>(nullable: false),
                    blockcode = table.Column<int>(nullable: false),
                    oncallstart = table.Column<DateTime>(type: "datetime", nullable: false),
                    oncallend = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_On-Call_Nurse",
                        column: x => x.nurse,
                        principalSchema: "Hospital",
                        principalTable: "Nurse",
                        principalColumn: "employeeid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_OnCall_Block",
                        columns: x => new { x.blockfloor, x.blockcode },
                        principalSchema: "Hospital",
                        principalTable: "Block",
                        principalColumns: new[] { "blockfloor", "blockcode" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "Hospital",
                columns: table => new
                {
                    departmentid = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    head = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.departmentid);
                    table.ForeignKey(
                        name: "FK_Department_Physician",
                        column: x => x.head,
                        principalSchema: "Hospital",
                        principalTable: "Physician",
                        principalColumn: "employeeid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                schema: "Hospital",
                columns: table => new
                {
                    ssn = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    insuranceid = table.Column<int>(nullable: true),
                    pcp = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.ssn);
                    table.ForeignKey(
                        name: "FK_Patient_Physician",
                        column: x => x.pcp,
                        principalSchema: "Hospital",
                        principalTable: "Physician",
                        principalColumn: "employeeid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trained_in",
                schema: "Hospital",
                columns: table => new
                {
                    physician = table.Column<int>(nullable: false),
                    treatment = table.Column<int>(nullable: false),
                    certificationdate = table.Column<DateTime>(type: "date", nullable: true),
                    certificationexpires = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Trained___9E42192E2FC97BA5", x => new { x.physician, x.treatment });
                    table.ForeignKey(
                        name: "FK_Trained_in_Physician",
                        column: x => x.physician,
                        principalSchema: "Hospital",
                        principalTable: "Physician",
                        principalColumn: "employeeid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trained_in_Procedures",
                        column: x => x.treatment,
                        principalSchema: "Hospital",
                        principalTable: "Procedures",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "HR",
                columns: table => new
                {
                    country_id = table.Column<string>(maxLength: 2, nullable: false),
                    country_name = table.Column<string>(maxLength: 40, nullable: true),
                    region_id = table.Column<decimal>(type: "numeric(10, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.country_id);
                    table.ForeignKey(
                        name: "FK_Countries_Regions",
                        column: x => x.region_id,
                        principalSchema: "HR",
                        principalTable: "Regions",
                        principalColumn: "region_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Inventory",
                columns: table => new
                {
                    ord_no = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    salesman_id = table.Column<decimal>(type: "numeric(5, 0)", nullable: true),
                    purch_amt = table.Column<decimal>(type: "numeric(8, 2)", nullable: true),
                    ord_date = table.Column<DateTime>(type: "date", nullable: true),
                    customer_id = table.Column<decimal>(type: "numeric(5, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ord_no);
                    table.ForeignKey(
                        name: "FK_Orders_Customer",
                        column: x => x.customer_id,
                        principalSchema: "Inventory",
                        principalTable: "Customer",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Salesman",
                        column: x => x.salesman_id,
                        principalSchema: "Inventory",
                        principalTable: "Salesman",
                        principalColumn: "salesman_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "player_mast",
                schema: "SOCCER",
                columns: table => new
                {
                    player_id = table.Column<int>(nullable: false),
                    team_id = table.Column<int>(nullable: true),
                    jersey_no = table.Column<int>(nullable: true),
                    player_name = table.Column<string>(maxLength: 40, nullable: true),
                    posi_to_play = table.Column<string>(maxLength: 2, nullable: true),
                    dt_of_bir = table.Column<DateTime>(type: "date", nullable: true),
                    age = table.Column<int>(nullable: true),
                    playing_club = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player_mast", x => x.player_id);
                    table.ForeignKey(
                        name: "FK_player_mast_playing_position",
                        column: x => x.posi_to_play,
                        principalSchema: "SOCCER",
                        principalTable: "playing_position",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "asst_referee_mast",
                schema: "SOCCER",
                columns: table => new
                {
                    ass_ref_id = table.Column<int>(nullable: false),
                    ass_ref_name = table.Column<string>(maxLength: 40, nullable: true),
                    country_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asst_referee_mast", x => x.ass_ref_id);
                    table.ForeignKey(
                        name: "FK_asst_referee_mast_soccer_country",
                        column: x => x.country_id,
                        principalSchema: "SOCCER",
                        principalTable: "soccer_country",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "referee_mast",
                schema: "SOCCER",
                columns: table => new
                {
                    referee_id = table.Column<int>(nullable: false),
                    referee_name = table.Column<string>(maxLength: 40, nullable: true),
                    country_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_referee_mast", x => x.referee_id);
                    table.ForeignKey(
                        name: "FK_referee_mast_soccer_country",
                        column: x => x.country_id,
                        principalSchema: "SOCCER",
                        principalTable: "soccer_country",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "soccer_city",
                schema: "SOCCER",
                columns: table => new
                {
                    city_id = table.Column<int>(nullable: false),
                    city = table.Column<string>(maxLength: 25, nullable: true),
                    country_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_soccer_city", x => x.city_id);
                    table.ForeignKey(
                        name: "FK_soccer_city_soccer_country",
                        column: x => x.country_id,
                        principalSchema: "SOCCER",
                        principalTable: "soccer_country",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "team_coaches",
                schema: "SOCCER",
                columns: table => new
                {
                    team_id = table.Column<int>(nullable: true),
                    coach_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_team_coaches_coach_mast",
                        column: x => x.coach_id,
                        principalSchema: "SOCCER",
                        principalTable: "coach_mast",
                        principalColumn: "coach_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_team_coaches_soccer_team",
                        column: x => x.team_id,
                        principalSchema: "SOCCER",
                        principalTable: "soccer_team",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Affiliated_With",
                schema: "Hospital",
                columns: table => new
                {
                    physician = table.Column<int>(nullable: false),
                    department = table.Column<int>(nullable: false),
                    primaryaffiliation = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Affiliat__82B9208A3D327DB9", x => new { x.physician, x.department });
                    table.ForeignKey(
                        name: "FK_Affiliated_With_Department",
                        column: x => x.department,
                        principalSchema: "Hospital",
                        principalTable: "Department",
                        principalColumn: "departmentid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Affiliated_With_Physician",
                        column: x => x.physician,
                        principalSchema: "Hospital",
                        principalTable: "Physician",
                        principalColumn: "employeeid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                schema: "Hospital",
                columns: table => new
                {
                    appointmentid = table.Column<int>(nullable: false),
                    patient = table.Column<int>(nullable: true),
                    prepnurse = table.Column<int>(nullable: true),
                    physician = table.Column<int>(nullable: true),
                    start_dt_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    end_dt_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    examinationroom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.appointmentid);
                    table.ForeignKey(
                        name: "FK_Appointment_Patient",
                        column: x => x.patient,
                        principalSchema: "Hospital",
                        principalTable: "Patient",
                        principalColumn: "ssn",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Physician",
                        column: x => x.physician,
                        principalSchema: "Hospital",
                        principalTable: "Physician",
                        principalColumn: "employeeid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Nurse",
                        column: x => x.prepnurse,
                        principalSchema: "Hospital",
                        principalTable: "Nurse",
                        principalColumn: "employeeid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stay",
                schema: "Hospital",
                columns: table => new
                {
                    stayid = table.Column<int>(nullable: false),
                    patient = table.Column<int>(nullable: true),
                    room = table.Column<int>(nullable: true),
                    start_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    end_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stay", x => x.stayid);
                    table.ForeignKey(
                        name: "FK_Stay_Patient",
                        column: x => x.patient,
                        principalSchema: "Hospital",
                        principalTable: "Patient",
                        principalColumn: "ssn",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stay_Room",
                        column: x => x.room,
                        principalSchema: "Hospital",
                        principalTable: "Room",
                        principalColumn: "roomnumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "HR",
                columns: table => new
                {
                    location_id = table.Column<decimal>(type: "numeric(4, 0)", nullable: false),
                    street_address = table.Column<string>(maxLength: 40, nullable: true),
                    postal_code = table.Column<string>(maxLength: 12, nullable: true),
                    city = table.Column<string>(maxLength: 30, nullable: true),
                    state_province = table.Column<string>(maxLength: 25, nullable: true),
                    country_id = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.location_id);
                    table.ForeignKey(
                        name: "FK__Locations__count__1DB06A4F",
                        column: x => x.country_id,
                        principalSchema: "HR",
                        principalTable: "Countries",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "soccer_venue",
                schema: "SOCCER",
                columns: table => new
                {
                    venue_id = table.Column<int>(nullable: false),
                    venue_name = table.Column<string>(maxLength: 30, nullable: true),
                    city_id = table.Column<int>(nullable: true),
                    aud_capacity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_soccer_venue", x => x.venue_id);
                    table.ForeignKey(
                        name: "FK_soccer_venue_soccer_city",
                        column: x => x.city_id,
                        principalSchema: "SOCCER",
                        principalTable: "soccer_city",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescribes",
                schema: "Hospital",
                columns: table => new
                {
                    physician = table.Column<int>(nullable: false),
                    patient = table.Column<int>(nullable: false),
                    medication = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    appointment = table.Column<int>(nullable: true),
                    dose = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Prescrib__2CED93CB1F2B9CEA", x => new { x.physician, x.patient, x.medication, x.date });
                    table.ForeignKey(
                        name: "FK_Prescribes_Appointment",
                        column: x => x.appointment,
                        principalSchema: "Hospital",
                        principalTable: "Appointment",
                        principalColumn: "appointmentid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescribes_Medication",
                        column: x => x.medication,
                        principalSchema: "Hospital",
                        principalTable: "Medication",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescribes_Patient",
                        column: x => x.patient,
                        principalSchema: "Hospital",
                        principalTable: "Patient",
                        principalColumn: "ssn",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescribes_Physician",
                        column: x => x.physician,
                        principalSchema: "Hospital",
                        principalTable: "Physician",
                        principalColumn: "employeeid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Undergoes",
                schema: "Hospital",
                columns: table => new
                {
                    patient = table.Column<int>(nullable: false),
                    procedure = table.Column<int>(nullable: false),
                    stay = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    physician = table.Column<int>(nullable: true),
                    assistingnurse = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Undergoe__296B7898CFAF34AD", x => new { x.patient, x.procedure, x.stay, x.date });
                    table.ForeignKey(
                        name: "FK_Undergoes_Nurse",
                        column: x => x.assistingnurse,
                        principalSchema: "Hospital",
                        principalTable: "Nurse",
                        principalColumn: "employeeid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Undergoes_Patient",
                        column: x => x.patient,
                        principalSchema: "Hospital",
                        principalTable: "Patient",
                        principalColumn: "ssn",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Undergoes_Physician",
                        column: x => x.physician,
                        principalSchema: "Hospital",
                        principalTable: "Physician",
                        principalColumn: "employeeid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Undergoes_Procedures",
                        column: x => x.procedure,
                        principalSchema: "Hospital",
                        principalTable: "Procedures",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Undergoes_Stay",
                        column: x => x.stay,
                        principalSchema: "Hospital",
                        principalTable: "Stay",
                        principalColumn: "stayid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "HR",
                columns: table => new
                {
                    department_id = table.Column<decimal>(type: "numeric(4, 0)", nullable: false),
                    department_name = table.Column<string>(maxLength: 30, nullable: true),
                    manager_id = table.Column<decimal>(type: "numeric(6, 0)", nullable: true),
                    location_id = table.Column<decimal>(type: "numeric(4, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.department_id);
                    table.ForeignKey(
                        name: "FK_Departments_Locations",
                        column: x => x.location_id,
                        principalSchema: "HR",
                        principalTable: "Locations",
                        principalColumn: "location_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "match_mast",
                schema: "SOCCER",
                columns: table => new
                {
                    match_no = table.Column<int>(nullable: false),
                    play_stage = table.Column<string>(maxLength: 1, nullable: true),
                    decided_by = table.Column<string>(maxLength: 1, nullable: true),
                    goal_score = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    play_date = table.Column<DateTime>(type: "date", nullable: true),
                    results = table.Column<string>(maxLength: 5, nullable: true),
                    venue_id = table.Column<int>(nullable: true),
                    referee_id = table.Column<int>(nullable: true),
                    audience = table.Column<int>(nullable: true),
                    plr_of_match = table.Column<int>(nullable: true),
                    stop1_sec = table.Column<int>(nullable: true),
                    stop2_sec = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_match_mast", x => x.match_no);
                    table.ForeignKey(
                        name: "FK_match_mast_referee_mast",
                        column: x => x.referee_id,
                        principalSchema: "SOCCER",
                        principalTable: "referee_mast",
                        principalColumn: "referee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_match_mast_soccer_venue",
                        column: x => x.venue_id,
                        principalSchema: "SOCCER",
                        principalTable: "soccer_venue",
                        principalColumn: "venue_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "HR",
                columns: table => new
                {
                    employee_id = table.Column<decimal>(type: "numeric(6, 0)", nullable: false),
                    first_name = table.Column<string>(maxLength: 20, nullable: true),
                    last_name = table.Column<string>(maxLength: 25, nullable: true),
                    email = table.Column<string>(maxLength: 25, nullable: true),
                    phone_number = table.Column<string>(maxLength: 20, nullable: true),
                    hire_date = table.Column<DateTime>(type: "date", nullable: true),
                    job_id = table.Column<string>(maxLength: 10, nullable: true),
                    salary = table.Column<decimal>(type: "numeric(8, 2)", nullable: true),
                    commission_pct = table.Column<decimal>(type: "numeric(2, 2)", nullable: true),
                    manager_id = table.Column<decimal>(type: "numeric(6, 0)", nullable: true),
                    department_id = table.Column<decimal>(type: "numeric(4, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees_1", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK__Employees__depar__18EBB532",
                        column: x => x.department_id,
                        principalSchema: "HR",
                        principalTable: "Departments",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Jobs",
                        column: x => x.job_id,
                        principalSchema: "HR",
                        principalTable: "Jobs",
                        principalColumn: "job_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "goal_details",
                schema: "SOCCER",
                columns: table => new
                {
                    goal_id = table.Column<int>(nullable: false),
                    match_no = table.Column<int>(nullable: true),
                    player_id = table.Column<int>(nullable: true),
                    team_id = table.Column<int>(nullable: true),
                    goal_time = table.Column<int>(nullable: true),
                    goal_type = table.Column<string>(maxLength: 1, nullable: true),
                    play_stage = table.Column<string>(maxLength: 1, nullable: true),
                    goal_schedule = table.Column<string>(maxLength: 2, nullable: true),
                    goal_half = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goal_details", x => x.goal_id);
                    table.ForeignKey(
                        name: "FK_goal_details_match_mast",
                        column: x => x.match_no,
                        principalSchema: "SOCCER",
                        principalTable: "match_mast",
                        principalColumn: "match_no",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_goal_detailsPlayer",
                        column: x => x.player_id,
                        principalSchema: "SOCCER",
                        principalTable: "player_mast",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_goal_details_soccer_team",
                        column: x => x.team_id,
                        principalSchema: "SOCCER",
                        principalTable: "soccer_team",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "match_captain",
                schema: "SOCCER",
                columns: table => new
                {
                    match_no = table.Column<int>(nullable: true),
                    team_id = table.Column<int>(nullable: true),
                    player_captain = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_match_captain_match_mast",
                        column: x => x.match_no,
                        principalSchema: "SOCCER",
                        principalTable: "match_mast",
                        principalColumn: "match_no",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_match_captain_soccer_team",
                        column: x => x.team_id,
                        principalSchema: "SOCCER",
                        principalTable: "soccer_team",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "match_details",
                schema: "SOCCER",
                columns: table => new
                {
                    match_no = table.Column<int>(nullable: true),
                    team_id = table.Column<int>(nullable: true),
                    play_stage = table.Column<string>(maxLength: 1, nullable: true),
                    win_lose = table.Column<string>(maxLength: 1, nullable: true),
                    decided_by = table.Column<string>(maxLength: 1, nullable: true),
                    goal_score = table.Column<int>(nullable: true),
                    penalty_score = table.Column<int>(nullable: true),
                    ass_ref = table.Column<int>(nullable: true),
                    player_gk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_match_details_asst_referee_mast",
                        column: x => x.ass_ref,
                        principalSchema: "SOCCER",
                        principalTable: "asst_referee_mast",
                        principalColumn: "ass_ref_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_match_details_match_mast",
                        column: x => x.match_no,
                        principalSchema: "SOCCER",
                        principalTable: "match_mast",
                        principalColumn: "match_no",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_match_details_soccer_team",
                        column: x => x.team_id,
                        principalSchema: "SOCCER",
                        principalTable: "soccer_team",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "penalty_gk",
                schema: "SOCCER",
                columns: table => new
                {
                    match_no = table.Column<int>(nullable: true),
                    team_id = table.Column<int>(nullable: true),
                    player_gk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_penalty_gk_match_mast",
                        column: x => x.match_no,
                        principalSchema: "SOCCER",
                        principalTable: "match_mast",
                        principalColumn: "match_no",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_penalty_gk_soccer_team",
                        column: x => x.team_id,
                        principalSchema: "SOCCER",
                        principalTable: "soccer_team",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "penalty_shootout",
                schema: "SOCCER",
                columns: table => new
                {
                    kick_id = table.Column<int>(nullable: false),
                    match_no = table.Column<int>(nullable: true),
                    team_id = table.Column<int>(nullable: true),
                    player_id = table.Column<int>(nullable: true),
                    score_goal = table.Column<string>(maxLength: 1, nullable: true),
                    kick_no = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_penalty_shootout", x => x.kick_id);
                    table.ForeignKey(
                        name: "FK_penalty_shootout_match_mast",
                        column: x => x.match_no,
                        principalSchema: "SOCCER",
                        principalTable: "match_mast",
                        principalColumn: "match_no",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_penalty_shootoutPlayer",
                        column: x => x.player_id,
                        principalSchema: "SOCCER",
                        principalTable: "player_mast",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_penalty_shootout_soccer_team",
                        column: x => x.team_id,
                        principalSchema: "SOCCER",
                        principalTable: "soccer_team",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "player_booked",
                schema: "SOCCER",
                columns: table => new
                {
                    match_no = table.Column<int>(nullable: true),
                    team_id = table.Column<int>(nullable: true),
                    player_id = table.Column<int>(nullable: true),
                    booking_time = table.Column<int>(nullable: true),
                    sent_off = table.Column<string>(maxLength: 1, nullable: true),
                    play_schedule = table.Column<string>(maxLength: 2, nullable: true),
                    play_half = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_player_booked_match_mast",
                        column: x => x.match_no,
                        principalSchema: "SOCCER",
                        principalTable: "match_mast",
                        principalColumn: "match_no",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_player_bookedPlayer",
                        column: x => x.player_id,
                        principalSchema: "SOCCER",
                        principalTable: "player_mast",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "player_in_out",
                schema: "SOCCER",
                columns: table => new
                {
                    match_no = table.Column<int>(nullable: true),
                    team_id = table.Column<int>(nullable: true),
                    player_id = table.Column<int>(nullable: true),
                    play_schedule = table.Column<string>(maxLength: 2, nullable: true),
                    play_half = table.Column<int>(nullable: true),
                    in_out = table.Column<string>(maxLength: 1, nullable: true),
                    time_in_out = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_player_in_out_match_mast",
                        column: x => x.match_no,
                        principalSchema: "SOCCER",
                        principalTable: "match_mast",
                        principalColumn: "match_no",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_player_in_outPlayer",
                        column: x => x.player_id,
                        principalSchema: "SOCCER",
                        principalTable: "player_mast",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_player_in_out_soccer_team",
                        column: x => x.team_id,
                        principalSchema: "SOCCER",
                        principalTable: "soccer_team",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Job_History",
                schema: "HR",
                columns: table => new
                {
                    employee_id = table.Column<decimal>(type: "numeric(6, 0)", nullable: false),
                    start_date = table.Column<DateTime>(type: "date", nullable: false),
                    end_date = table.Column<DateTime>(type: "date", nullable: true),
                    job_id = table.Column<string>(maxLength: 10, nullable: true),
                    department_id = table.Column<decimal>(type: "numeric(4, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job_History", x => new { x.employee_id, x.start_date });
                    table.ForeignKey(
                        name: "FK_Job_History_Departments",
                        column: x => x.department_id,
                        principalSchema: "HR",
                        principalTable: "Departments",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Job_Histo__emplo__1AD3FDA4",
                        column: x => x.employee_id,
                        principalSchema: "HR",
                        principalTable: "Employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Job_History_Jobs",
                        column: x => x.job_id,
                        principalSchema: "HR",
                        principalTable: "Jobs",
                        principalColumn: "job_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employees_dep_id",
                schema: "Employee",
                table: "employees",
                column: "dep_id");

            migrationBuilder.CreateIndex(
                name: "IX_Affiliated_With_department",
                schema: "Hospital",
                table: "Affiliated_With",
                column: "department");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_patient",
                schema: "Hospital",
                table: "Appointment",
                column: "patient");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_physician",
                schema: "Hospital",
                table: "Appointment",
                column: "physician");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_prepnurse",
                schema: "Hospital",
                table: "Appointment",
                column: "prepnurse");

            migrationBuilder.CreateIndex(
                name: "IX_Department_head",
                schema: "Hospital",
                table: "Department",
                column: "head");

            migrationBuilder.CreateIndex(
                name: "IX_On-Call_nurse",
                schema: "Hospital",
                table: "On-Call",
                column: "nurse");

            migrationBuilder.CreateIndex(
                name: "IX_On-Call_blockfloor_blockcode",
                schema: "Hospital",
                table: "On-Call",
                columns: new[] { "blockfloor", "blockcode" });

            migrationBuilder.CreateIndex(
                name: "IX_Patient_pcp",
                schema: "Hospital",
                table: "Patient",
                column: "pcp");

            migrationBuilder.CreateIndex(
                name: "IX_Prescribes_appointment",
                schema: "Hospital",
                table: "Prescribes",
                column: "appointment");

            migrationBuilder.CreateIndex(
                name: "IX_Prescribes_medication",
                schema: "Hospital",
                table: "Prescribes",
                column: "medication");

            migrationBuilder.CreateIndex(
                name: "IX_Prescribes_patient",
                schema: "Hospital",
                table: "Prescribes",
                column: "patient");

            migrationBuilder.CreateIndex(
                name: "IX_Room_blockfloor_blockcode",
                schema: "Hospital",
                table: "Room",
                columns: new[] { "blockfloor", "blockcode" });

            migrationBuilder.CreateIndex(
                name: "IX_Stay_patient",
                schema: "Hospital",
                table: "Stay",
                column: "patient");

            migrationBuilder.CreateIndex(
                name: "IX_Stay_room",
                schema: "Hospital",
                table: "Stay",
                column: "room");

            migrationBuilder.CreateIndex(
                name: "IX_Trained_in_treatment",
                schema: "Hospital",
                table: "Trained_in",
                column: "treatment");

            migrationBuilder.CreateIndex(
                name: "IX_Undergoes_assistingnurse",
                schema: "Hospital",
                table: "Undergoes",
                column: "assistingnurse");

            migrationBuilder.CreateIndex(
                name: "IX_Undergoes_physician",
                schema: "Hospital",
                table: "Undergoes",
                column: "physician");

            migrationBuilder.CreateIndex(
                name: "IX_Undergoes_procedure",
                schema: "Hospital",
                table: "Undergoes",
                column: "procedure");

            migrationBuilder.CreateIndex(
                name: "IX_Undergoes_stay",
                schema: "Hospital",
                table: "Undergoes",
                column: "stay");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_region_id",
                schema: "HR",
                table: "Countries",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_location_id",
                schema: "HR",
                table: "Departments",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_department_id",
                schema: "HR",
                table: "Employees",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_job_id",
                schema: "HR",
                table: "Employees",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_Job_History_department_id",
                schema: "HR",
                table: "Job_History",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Job_History_job_id",
                schema: "HR",
                table: "Job_History",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_country_id",
                schema: "HR",
                table: "Locations",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customer_id",
                schema: "Inventory",
                table: "Orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_salesman_id",
                schema: "Inventory",
                table: "Orders",
                column: "salesman_id");

            migrationBuilder.CreateIndex(
                name: "IX_asst_referee_mast_country_id",
                schema: "SOCCER",
                table: "asst_referee_mast",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_goal_details_match_no",
                schema: "SOCCER",
                table: "goal_details",
                column: "match_no");

            migrationBuilder.CreateIndex(
                name: "IX_goal_details_player_id",
                schema: "SOCCER",
                table: "goal_details",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "IX_goal_details_team_id",
                schema: "SOCCER",
                table: "goal_details",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_match_captain_match_no",
                schema: "SOCCER",
                table: "match_captain",
                column: "match_no");

            migrationBuilder.CreateIndex(
                name: "IX_match_captain_team_id",
                schema: "SOCCER",
                table: "match_captain",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_match_details_ass_ref",
                schema: "SOCCER",
                table: "match_details",
                column: "ass_ref");

            migrationBuilder.CreateIndex(
                name: "IX_match_details_match_no",
                schema: "SOCCER",
                table: "match_details",
                column: "match_no");

            migrationBuilder.CreateIndex(
                name: "IX_match_details_team_id",
                schema: "SOCCER",
                table: "match_details",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_match_mast_referee_id",
                schema: "SOCCER",
                table: "match_mast",
                column: "referee_id");

            migrationBuilder.CreateIndex(
                name: "IX_match_mast_venue_id",
                schema: "SOCCER",
                table: "match_mast",
                column: "venue_id");

            migrationBuilder.CreateIndex(
                name: "IX_penalty_gk_match_no",
                schema: "SOCCER",
                table: "penalty_gk",
                column: "match_no");

            migrationBuilder.CreateIndex(
                name: "IX_penalty_gk_team_id",
                schema: "SOCCER",
                table: "penalty_gk",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_penalty_shootout_match_no",
                schema: "SOCCER",
                table: "penalty_shootout",
                column: "match_no");

            migrationBuilder.CreateIndex(
                name: "IX_penalty_shootout_player_id",
                schema: "SOCCER",
                table: "penalty_shootout",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "IX_penalty_shootout_team_id",
                schema: "SOCCER",
                table: "penalty_shootout",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_player_booked_match_no",
                schema: "SOCCER",
                table: "player_booked",
                column: "match_no");

            migrationBuilder.CreateIndex(
                name: "IX_player_booked_player_id",
                schema: "SOCCER",
                table: "player_booked",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "IX_player_in_out_match_no",
                schema: "SOCCER",
                table: "player_in_out",
                column: "match_no");

            migrationBuilder.CreateIndex(
                name: "IX_player_in_out_player_id",
                schema: "SOCCER",
                table: "player_in_out",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "IX_player_in_out_team_id",
                schema: "SOCCER",
                table: "player_in_out",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_player_mast_posi_to_play",
                schema: "SOCCER",
                table: "player_mast",
                column: "posi_to_play");

            migrationBuilder.CreateIndex(
                name: "IX_referee_mast_country_id",
                schema: "SOCCER",
                table: "referee_mast",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_soccer_city_country_id",
                schema: "SOCCER",
                table: "soccer_city",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_soccer_venue_city_id",
                schema: "SOCCER",
                table: "soccer_venue",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_team_coaches_coach_id",
                schema: "SOCCER",
                table: "team_coaches",
                column: "coach_id");

            migrationBuilder.CreateIndex(
                name: "IX_team_coaches_team_id",
                schema: "SOCCER",
                table: "team_coaches",
                column: "team_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "salary_grade",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "Affiliated_With",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "On-Call",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Prescribes",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Trained_in",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Undergoes",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Job_Grades",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Job_History",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Actor",
                schema: "Movies");

            migrationBuilder.DropTable(
                name: "Director",
                schema: "Movies");

            migrationBuilder.DropTable(
                name: "Genres",
                schema: "Movies");

            migrationBuilder.DropTable(
                name: "Movie",
                schema: "Movies");

            migrationBuilder.DropTable(
                name: "Movie_cast",
                schema: "Movies");

            migrationBuilder.DropTable(
                name: "Movie_Direction",
                schema: "Movies");

            migrationBuilder.DropTable(
                name: "Movie_Genres",
                schema: "Movies");

            migrationBuilder.DropTable(
                name: "Rating",
                schema: "Movies");

            migrationBuilder.DropTable(
                name: "Reviewer",
                schema: "Movies");

            migrationBuilder.DropTable(
                name: "goal_details",
                schema: "SOCCER");

            migrationBuilder.DropTable(
                name: "match_captain",
                schema: "SOCCER");

            migrationBuilder.DropTable(
                name: "match_details",
                schema: "SOCCER");

            migrationBuilder.DropTable(
                name: "penalty_gk",
                schema: "SOCCER");

            migrationBuilder.DropTable(
                name: "penalty_shootout",
                schema: "SOCCER");

            migrationBuilder.DropTable(
                name: "player_booked",
                schema: "SOCCER");

            migrationBuilder.DropTable(
                name: "player_in_out",
                schema: "SOCCER");

            migrationBuilder.DropTable(
                name: "team_coaches",
                schema: "SOCCER");

            migrationBuilder.DropTable(
                name: "department",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Appointment",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Medication",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Procedures",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Stay",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Salesman",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "asst_referee_mast",
                schema: "SOCCER");

            migrationBuilder.DropTable(
                name: "match_mast",
                schema: "SOCCER");

            migrationBuilder.DropTable(
                name: "player_mast",
                schema: "SOCCER");

            migrationBuilder.DropTable(
                name: "coach_mast",
                schema: "SOCCER");

            migrationBuilder.DropTable(
                name: "soccer_team",
                schema: "SOCCER");

            migrationBuilder.DropTable(
                name: "Nurse",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Patient",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Room",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Jobs",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "referee_mast",
                schema: "SOCCER");

            migrationBuilder.DropTable(
                name: "soccer_venue",
                schema: "SOCCER");

            migrationBuilder.DropTable(
                name: "playing_position",
                schema: "SOCCER");

            migrationBuilder.DropTable(
                name: "Physician",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Block",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Locations",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "soccer_city",
                schema: "SOCCER");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "soccer_country",
                schema: "SOCCER");

            migrationBuilder.DropTable(
                name: "Regions",
                schema: "HR");
        }
    }
}
