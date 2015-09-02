
SELECT 
	 Lvl
	,TableName
FROM V_DEV_InsertDataDependency
WHERE (1=1) 
AND TableName NOT IN ('dtproperties', 'sysdiagrams')

AND TableName LIKE 'T\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_BO\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_COR\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_DMS\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_Import\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_Export\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_EXPL\_%' ESCAPE '\'

AND TableName NOT LIKE 'T\_FMS\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_LOG\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_RPT\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_Slick%' ESCAPE '\'
AND TableName NOT LIKE 'T\_SYS\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_ZO\_SYS\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_OV\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_ZO\_OV\_Ref\_%' ESCAPE '\'

AND TableName NOT LIKE 'T\_ZO\_AP\_%\_DWG' ESCAPE '\'
AND TableName NOT LIKE 'T\_ZO\_AP\_%\_Flaeche' ESCAPE '\'

AND TableName NOT LIKE 'T\_POM\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_VAR\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_OR\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_UM\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_REM\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_ZO\_REM\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_MM\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_ZO\_MM\_%' ESCAPE '\'



AND TableName NOT IN 
(
	 'T_AP_DWGSAVE', 'T_AP_DWGSAVE_XREF', 'T_AP_LinkDWG', 'T_AP_LinkDWG_XREF', 'T_ZO_AP_MarkDWG' 
	,'T_AP_Legenden', 'T_AP_Legende_Sort', 'T_Image' 
	,'T_AP_Ref_Mandant_Logo','T_AP_Ref_DIN277', 'T_VWS_PortalTree', 'ELMAH_Error' 
	,'T_Admin', 'T_Benutzergruppen_Portal','T_Benutzer', 'T_Benutzergruppen','T_Benutzer_Benutzergruppen', 'T_Benutzerrechte' 
	,'T_ZO_Benutzer_Mandant','T_ZO_Benutzer_Schedule', 'T_ZO_AP_Raum_OBJT_Kategorie' 
) 


AND TableName NOT LIKE 'T\_AP\_%\_History' ESCAPE '\'
AND TableName NOT LIKE 'T\_AV\_%\_History' ESCAPE '\'
AND TableName NOT LIKE 'T\_MM\_%\_History' ESCAPE '\'
AND TableName NOT LIKE 'T\_VM\_%\_History' ESCAPE '\'

AND TableName NOT LIKE 'T\_Ref\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_AP\_Ref\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_ALV\_Ref\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_AV\_Ref\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_TM\_Ref\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_UPS\_Ref\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_UM\_Ref\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_UW\_Ref\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_VM\_Ref\_%' ESCAPE '\'
AND TableName NOT LIKE 'T\_AP\_Kunst\_Ref\_%' ESCAPE '\'


--AND TableName LIKE '%SYS%'

ORDER BY 
	 Lvl 
	,TableName 
	
