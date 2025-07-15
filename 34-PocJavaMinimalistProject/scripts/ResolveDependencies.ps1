# Script from Copilot to test

# === CONFIG ===
$jarPath = "jgit-6.4.0.jar"
$libsFolder = "libs"
$outputFile = "missing_deps.txt"

# === Ensure folders exist ===
if (!(Test-Path $libsFolder)) { New-Item -ItemType Directory -Path $libsFolder | Out-Null }

# === Run jdeps ===
jdeps -verbose:class -recursive $jarPath | 
    Select-String "not found" | 
    ForEach-Object {
        $_.Line -replace '.*->\s+(.*)\s+not found.*', '$1'
    } | Sort-Object -Unique |
    Set-Content $outputFile

# === Mapping (add/edit manually for accuracy) ===
$mapping = @{
    "org.slf4j" = "org/slf4j/slf4j-api/1.7.36/slf4j-api-1.7.36.jar"
    "org.apache.sshd" = "org/apache/sshd/sshd-core/2.7.0/sshd-core-2.7.0.jar"
    "org.apache.commons.lang3" = "org/apache/commons/commons-lang3/3.12.0/commons-lang3-3.12.0.jar"
    "com.googlecode.javaewah" = "com/googlecode/javaewah/JavaEWAH/1.1.13/JavaEWAH-1.1.13.jar"
    "net.i2p.crypto" = "net/i2p/crypto/eddsa/0.3.0/eddsa-0.3.0.jar"
}

# === Generate Maven URLs ===
Get-Content $outputFile | ForEach-Object {
    foreach ($key in $mapping.Keys) {
        if ($_ -like "$key*") {
            $url = "https://repo1.maven.org/maven2/$($mapping[$key])"
            Write-Host "🔗 $_ → $url"
        }
    }
}

# === Optional: Download missing JARs
<# 
Get-Content $outputFile | ForEach-Object {
    foreach ($key in $mapping.Keys) {
        if ($_ -like "$key*") {
            $fileName = [System.IO.Path]::GetFileName($mapping[$key])
            $url = "https://repo1.maven.org/maven2/$($mapping[$key])"
            $dest = "$libsFolder\$fileName"
            if (!(Test-Path $dest)) {
                Write-Host "⬇️ Downloading: $fileName"
                Invoke-WebRequest -Uri $url -OutFile $dest
            }
        }
    }
}
#>
