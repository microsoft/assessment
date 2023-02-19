<#
.SYNOPSIS
    Reads Zero Trust scenarios from Excel and generates corresponding C# code to represent scenarios.
.DESCRIPTION
    This cmdlet assumes the file ZeroTrust config file 'Zero Trust Scenarios_ForWizards_UseThisCopy.xlsx' 
    stored in the ZT Advisory V-Team SharePoint site has been synced to the local device where this script is running.
    Run the script to import the latest wording from the config file
.EXAMPLE
    PS C:\> Import-ZeroTrustScenarios 
        -ExcelPath 'F:\OneDrive\Zero Trust Scenarios_ForWizards_UseThisCopy.xlsx' 
        -Src 'F:\Code\msassessment\src\Assessment\Assessment.Shared\ZeroTrust\ZeroTrustDataService.cs'    
#>

