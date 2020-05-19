

$pool = [runspacefactory]::CreateRunspacePool(1, 3)

$pool.Open()

$p1 = [PowerShell]::Create().AddCommand("Get-Process").AddCommand("Out-String")

$p1.RunspacePool = $pool



$process = $p1.Invoke()

$process

