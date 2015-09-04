
-- http://dba.stackexchange.com/questions/15596/sql-query-slow-down-from-1-second-to-11-minutes-why

;WITH Fkeys AS (

    SELECT DISTINCT 
         OnTable       = OnTable.name
        ,AgainstTable  = AgainstTable.name 
    FROM sysforeignkeys fk 

        INNER JOIN sysobjects onTable 
            ON fk.fkeyid = onTable.id 

        INNER JOIN sysobjects againstTable  
            ON fk.rkeyid = againstTable.id 

    WHERE 1=1
        AND AgainstTable.TYPE = 'U'
        AND OnTable.TYPE = 'U'
        -- ignore self joins; they cause an infinite recursion
        AND OnTable.Name <> AgainstTable.Name
    )

,MyData AS (

    SELECT 
         OnTable = o.name 
        ,AgainstTable = FKeys.againstTable 
    FROM sys.objects o 

    LEFT JOIN FKeys
        ON o.name = FKeys.onTable 

    WHERE (1=1) 
        AND o.type = 'U' 
        AND o.name NOT LIKE 'sys%' 
    )

,MyRecursion AS (

    -- base case
    SELECT  
         TableName    = OnTable
        ,Lvl        = 1
    FROM MyData
    WHERE 1=1
        AND AgainstTable IS NULL 

    -- recursive case
    UNION ALL 

    SELECT 
         TableName = OnTable 
        ,Lvl       = r.Lvl + 1 
    FROM MyData d 
        INNER JOIN MyRecursion r 
            ON d.AgainstTable = r.TableName 
)
SELECT 
     Lvl = MAX(Lvl)
    ,TableName
    --,strSql = 'delete from [' + tablename + ']'
FROM 
    MyRecursion
GROUP BY
    TableName

ORDER BY lvl

