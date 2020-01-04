# reportportal-cli
Command line utility to interact with http://reportportal.io via API

This is command line utility, would be nice to have it to interact with ReportPortal API. Just an idea how to easily create a launch and share it for agents to report test results into this launch.

# Install

## As dotnet tool from nuget.org
```
dotnet tool install reportportal -g
```

# Usage
Then we need configure a connection with api
```cmd
reportportal configure -s http://<host>/api/v1 -p <some_project> -u <some_api_token>
```

And start a launch
```cmd
reportportal launch start -n <some_name> -d <some_description>
```

And finish the launch
```cmd
reportportal launch finish -s passed
```

Or search for launches
```cmd
reportportal launch get --filter name.cnt=<some_part_of_name>
```

# Global context
It's important that tool sets/shares global context. When tool creates a launch, its sets ID of launch as global variable. Then all commands, which want to interact with launch, do it implicitly.

```cmd
reportportal test get
```

This command should show all tests that belong to previously set launch.