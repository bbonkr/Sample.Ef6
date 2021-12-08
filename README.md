# EntityFrameworkCore 6

Verify what chages EntityFrameworkCore 6

## Owned property

AppUser 

```sql
CREATE TABLE [dbo].[AppUsers](
	[Id]        [nvarchar](36) NOT NULL,
	[Name]      [nvarchar](200) NOT NULL,
	[Email]     [nvarchar](200) NOT NULL,
    CONSTRAINT [PK_AppUsers] PRIMARY KEY CLUSTERED 
    (
	    [Id] ASC
    )
)
```

UserAddress

```sql
CREATE TABLE [dbo].[UserAddress](
	[UserId]    [nvarchar](36) NOT NULL,
	[Country]   [nvarchar](100) NOT NULL,
	[City]      [nvarchar](1000) NOT NULL,
	[State]     [nvarchar](1000) NOT NULL,
	[Line1]     [nvarchar](1000) NULL,
	[Line2]     [nvarchar](1000) NULL,
	[ZipCode]   [nvarchar](100) NULL,
    CONSTRAINT [PK_UserAddress] PRIMARY KEY CLUSTERED 
    (
	    [UserId] ASC
    )
)
GO
ALTER TABLE [dbo].[UserAddress]  WITH CHECK ADD  CONSTRAINT [FK_UserAddress_AppUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserAddress] CHECK CONSTRAINT [FK_UserAddress_AppUsers_UserId]
GO
```