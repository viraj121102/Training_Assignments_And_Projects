
select * from AspNetRoles;

-- Insert values
INSERT INTO dbo.AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp)
VALUES (
    103,                        
    'marketer',                       
    'MARKETER',                   
    NEWID()     -- Unique value for concurrency tracking
);

-- Delete Row using id
DELETE FROM dbo.AspNetRoles
WHERE Id = '19A42043-F945-439F-9228-5C1DE0030475';




select * from AspNetUserRoles;


INSERT INTO AspNetUserRoles (UserId, RoleId)
VALUES ( 
    '73f48b78-2a1e-411a-a73c-518023f6922b',
    102
)

select * from AspNetUsers;


DELETE FROM dbo.AspNetUsers
WHERE Id = '20021ad5-8854-472b-89a9-223df02fe9d4';


select * From __EFMigrationsHistory;

select * from patients;