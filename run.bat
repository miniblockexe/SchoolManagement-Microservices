start cmd /k "cd StudentService && dotnet run"
start cmd /k "cd TeacherService && dotnet run"
start cmd /k "cd ClassService && dotnet run"

timeout /t 5

start http://localhost:3456/swagger
start http://localhost:5678/swagger
start http://localhost:6789/swagger