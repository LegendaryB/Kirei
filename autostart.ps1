$registryPath = ""
$name = "Kirei"
$value = $PSScriptRoot + "\Kirei.exe"

New-ItemProperty -Path $registryPath -Name $name -Value $value -PropertyType String -Force | Out-Null