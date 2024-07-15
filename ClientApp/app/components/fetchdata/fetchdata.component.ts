import { Component, ViewChild, ViewEncapsulation, OnInit, Inject } from '@angular/core';
import { DatePicker } from '@syncfusion/ej2-calendars';
import { Column, EditSettingsModel, ToolbarItems, IEditCell } from '@syncfusion/ej2-angular-grids';
import { DataManager, WebApiAdaptor, UrlAdaptor, Query } from '@syncfusion/ej2-data';
import { SaveEventArgs, IRow } from '@syncfusion/ej2-grids';
import { DropDownList } from '@syncfusion/ej2-dropdowns';
import { GridComponent } from '@syncfusion/ej2-angular-grids';
import { InfiniteScrollService } from '@syncfusion/ej2-angular-grids';
import { employeeData, customerData, orderData, orderDatas } from './datasource';
import { PageSettingsModel, InfiniteScrollSettingsModel } from '@syncfusion/ej2-angular-grids';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html',
    encapsulation: ViewEncapsulation.Emulated,
    providers: [InfiniteScrollService]
})
export class FetchDataComponent {
    public data: any;
    public editSettings: Object;
    public toolbar: string[];
    public filterSettings: Object;
    public options: PageSettingsModel;
    public infiniteOptions: InfiniteScrollSettingsModel;

  @ViewChild('grid')
    public grid: GridComponent;
    public query: Query;


    ngOnInit(): void {
        this.options = { pageSize: 50 };
        this.infiniteOptions = { initialBlocks: 5 };
        this.toolbar = ["Add","Delete", "Update"];
        this.editSettings = { allowEditing: true, allowDeleting: true, allowAdding: true, mode:"Batch" };
    this.data = new DataManager({
        url: 'Home/UrlDatasource',
        batchUrl: "/Home/BatchUpdate",
        adaptor: new UrlAdaptor()
    });
        this.filterSettings = { type: "Menu" };
       
    }

}

