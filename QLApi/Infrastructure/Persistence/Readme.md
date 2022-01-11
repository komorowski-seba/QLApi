### Migration ###

### add ###
dotnet ef --startup-project ../Api migrations add ql_air_test_db -o Persistence/Migrations -c ApplicationDbContext --verbose