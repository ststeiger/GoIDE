
-- http://dba.stackexchange.com/questions/15596/sql-query-slow-down-from-1-second-to-11-minutes-why

WITH RECURSIVE Fkeys AS 
(
    SELECT DISTINCT 
         KCU1.TABLE_NAME AS OnTable 
        ,KCU2.TABLE_NAME AS AgainstTable 
    FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS RC 

    LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE KCU1 
        ON KCU1.CONSTRAINT_CATALOG = RC.CONSTRAINT_CATALOG  
        AND KCU1.CONSTRAINT_SCHEMA = RC.CONSTRAINT_SCHEMA 
        AND KCU1.CONSTRAINT_NAME = RC.CONSTRAINT_NAME 

    LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE KCU2 
        ON KCU2.CONSTRAINT_CATALOG =  RC.UNIQUE_CONSTRAINT_CATALOG  
        AND KCU2.CONSTRAINT_SCHEMA = RC.UNIQUE_CONSTRAINT_SCHEMA 
        AND KCU2.CONSTRAINT_NAME = RC.UNIQUE_CONSTRAINT_NAME 
        AND KCU2.ORDINAL_POSITION = KCU1.ORDINAL_POSITION 
)

,MyData AS 
( 
    SELECT 
         TABLE_NAME AS OnTable  
        ,FKeys.againstTable AS AgainstTable
    FROM INFORMATION_SCHEMA.TABLES 

    LEFT JOIN FKeys
        ON TABLE_NAME = FKeys.onTable  

    WHERE (1=1) 
        AND TABLE_TYPE = 'BASE TABLE'
        AND TABLE_SCHEMA = 'public'
        --AND TABLE_NAME NOT IN ('sysdiagrams', 'dtproperties') 
)


,MyRecursion AS 
(
    -- base case
    SELECT  
         OnTable AS TableName 
        ,1 AS Lvl 
    FROM MyData
    WHERE 1=1
    AND AgainstTable IS NULL 

    -- recursive case
    UNION ALL 

    SELECT 
         OnTable AS TableName
        ,r.Lvl + 1 AS Lvl 
    FROM MyData d 

    INNER JOIN MyRecursion r 
        ON d.AgainstTable = r.TableName 
)

SELECT 
     MAX(Lvl) AS Lvl 
    ,TableName
    --,strSql = 'delete from [' + tablename + ']'
FROM 
    MyRecursion
GROUP BY
    TableName

ORDER BY lvl
