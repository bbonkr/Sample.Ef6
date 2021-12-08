$message = $args[0];
echo $message

if([string]::IsNullOrEmpty($message)){
    echo ""
    echo "Please input migration message that pass through first argument."
    echo "e.g.)"
    echo "PS> ef-migration-add.ps1 'My first migration'"
    echo ""
}
else{
    cd ./src/Sample.Ef6.Data

    dotnet ef migrations add $message --context ApplicationDbContext --startup-project ../Sample.Ef6.App --project ../Sample.Ef6.Data.SqlServer --json

    cd ../../
}
