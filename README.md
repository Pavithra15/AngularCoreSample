# ASP-Core-Angular

## Integrate the Angular Sample with ASP core
We can integrate the Angular sample with ASP core. ASP.NET Single Page Application(SPA) helps you to build applications that include significant client-side interactions using HTML 5, CSS 3 and Typescript.

To getting started with Syncfusion Angular Components, the NPM packages and Syncfusion packages helps to seamlessly supports ASP.NET Core environment for our components. The following steps depicts, to create an application in ASP.NET Core using SPA template with EJ2-Syncfusion Angular Grid Components.
## Install the SPA template
To create a new application in .NET Core, we should install the Single Page Application(SPA) template by following command.

dotnet new --install Microsoft.AspNetCore.SpaTemplates::*
To generate a new Angular project run the below command in your directory.

**dotnet new angular**

## Install the Dependencies

To restore the .NET dependencies and install the NPM dependencies, run the below command in your root directory.

**dotnet restore**
**npm install**

## Configuration of Syncfusion EJ2-Angular Grid Component
**npm install @syncfusion/ej2-ng-grids --save**

## Import Grid module into app.module.shared.ts file.

import { NgModule } from '@angular/core';
.  .  .
import { GridAllModule, PageService, ToolbarService, FilterService, SortService } from '@syncfusion/ej2-ng-grids';

@NgModule({
    . . .
     providers: [PageService, ToolbarService, FilterService, SortService],
    imports: [
       .  . .
        GridAllModule,
       .  . .
    ]
})
export class AppModuleShared {
}

## Run the Application
After the Download the Sample from this branch install the npm packages and Syncfusion packages from following commands in your root directory.

**dotnet restore**

**npm install**

**npm install @syncfusion/ej2-ng-grids --save**

Now you can run the Integrated ASP core project.

