
$process = Get-Process

foreach($proc in $process)
{
	
	[PSCustomObject]@{
    Name     = $proc.Name
    Id      = $proc.Id
    Path    = $proc.Path
}

}