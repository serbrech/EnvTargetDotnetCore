# EnvTargetDotnetCore
Sample app to test the behaviour of Environment variable targets on linux/windows in dotnet core

The console app adds a variable in each target following this convention

    EnvTarget-[Target] = EnvironmentVariableTarget.[Target]

I also added an environment variable from the Dockerfile to see where it ends up.  
Then the app lists all variables in each target.

## TL;DR
- Setting variable in linux only works with `EnvironmentTarget.Process`. Other targets do nothing.
- Everything works as expected on windows.
- Dockerfile ENV directive sets the variable on the `Process` target 

## Test behaviour on Linux using Docker : 

    docker build -t test-env-target
    docker run test-env-target  


Result : 
```
OS : Unix 4.9.41.0

Setting Environment Variables on all 3 targets                                   
EnvironmentVariableTarget.Machine :

EnvironmentVariableTarget.User :

EnvironmentVariableTarget.Process :                                                                                                                        
PATH = /usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin                                        
...
DOTNET_SDK_VERSION = 2.0.0                                      
EnvironmentVariable-FromDockerfile = FromDockerfile                                
EnvTarget-Process = EnvironmentVariableTarget.Process
```
## On Windows

### Locally :

    dotnet publish -c release -o published
    dotnet .\published\EnvironmentVariablesTarget.dll

### From a windows nano container : 

First switch daemon to the windows daemon : 
    
    & $Env:ProgramFiles\Docker\Docker\DockerCli.exe -SwitchDaemon

And then :

    dotnet build -f Dockerfile.win -t test-env-target
    docker run --rm test-env-target

Output on Windows (truncated to the useful parts) :

    OS : Microsoft Windows NT 6.2.9200.0
    Setting Environment Variables on all 3 targets

    EnvironmentVariableTarget.Machine :
    PROCESSOR_LEVEL = 6
    OS = Windows_NT
    ...
    EnvTarget-Machine = EnvironmentVariableTarget.Machine

    EnvironmentVariableTarget.User :
    EnvTarget-User = EnvironmentVariableTarget.User
    ...


    EnvironmentVariableTarget.Process : 
    EnvironmentVariable-FromDockerfile = FromDockerfile # if running in docker
    EnvTarget-Process = EnvironmentVariableTarget.Process
    ...

