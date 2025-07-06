@ECHO OFF
PUSHD %~dp0
ManualTests.Net20\bin\Debug\net20\  ManualTests.Net20.exe
ManualTests.Net30\bin\Debug\net30\  ManualTests.Net30.exe
ManualTests.Net35\bin\Debug\net35\  ManualTests.Net35.exe
ManualTests.Net40\bin\Debug\net40\  ManualTests.Net40.exe
ManualTests.Net403\bin\Debug\net403\ManualTests.Net403.exe
ManualTests.Net45\bin\Debug\net45\  ManualTests.Net45.exe
ManualTests.Net451\bin\Debug\net451\ManualTests.Net451.exe
ManualTests.Net452\bin\Debug\net452\ManualTests.Net452.exe
ManualTests.Net46\bin\Debug\net46\  ManualTests.Net46.exe
ManualTests.Net461\bin\Debug\net461\ManualTests.Net461.exe
ECHO:
ECHO Press ENTER to continue
PAUSE >NUL
POPD
