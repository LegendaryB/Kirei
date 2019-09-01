$RegistryKey = "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run"
$RegistryValue = "Kirei"
$RegistryData = $PSScriptRoot + "\Kirei.exe"

Write-Host $RegistryData

Try
{
	New-ItemProperty -Type "String" -Path $RegistryKey -Name $RegistryValue -Value $RegistryData -Force
}
catch 
{
	Write-Error -Message $_
}