<p align="center">
	<img alt="logo" width="100" src="https://static.snoozemo.com/i/public/pch.ico.png">
</p>
<hr>
<p align="center">
   <b>Phantom Channel:</b> 
    以投票为主题的网络社区软件-服务端
</p>

```json
/* appsettings.Development.json */
{
    // ......
    "ConnectionStrings": {
        // ......
        "DefaultConnection": "Server=localhost;Port=5432;Database=database_name;User Id=postgres;Password=password;",
        "EmailConnection": "Host=host,Port=port,UserName=account,Password=password"
    },
    "AllowedHosts": "*",
    "Jwt": {
        "Key": "key_",
        "Issuer": "Issuer_",
        "Audience": "Audience_",
        "ExpireMinutes": 20160
    }
}
```

```shell
# Code First
dotnet ef migrations add [xxxxx] -p src/PhantomChannel.Server.Infrastructure -s src/PhantomChannel.Server.Api
# Push Migration
dotnet ef database update -p src/PhantomChannel.Server.Infrastructure -s src/PhantomChannel.Server.Api
# Cli Startup
dotnet watch run --project   .\src\PhantomChannel.Server.Api\PhantomChannel.Server.Api.csproj --environment  development
```

## 目录结构

```shell
.
├── src
│   ├── PhantomChannel.Server.Api
│   ├── PhantomChannel.Server.Application
│   ├── PhantomChannel.Server.Domain
│   ├── PhantomChannel.Server.Infrastructure
```
