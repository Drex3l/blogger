import { CreateCategoryInput } from './../../../shared/service-proxies/service-proxies';
import { Component, OnInit, ViewChild, ElementRef, Output, EventEmitter, Injector } from '@angular/core';
import { CategoryServiceProxy } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';

@Component({
    selector: 'create-category-modal',
    templateUrl: './create-category.component.html',
    providers: [CategoryServiceProxy]
})
export class CreateCategoryComponent extends AppComponentBase implements OnInit {

    @ViewChild('createCategoryModal') modal: ModalDirective;
    @ViewChild('modalContent') modalContent: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active: boolean = false;
    saving: boolean = false;
    category: CreateCategoryInput = null;

    constructor(
        injector: Injector,
        private _categoryService: CategoryServiceProxy,
    ) {
        super(injector);
    }

    ngOnInit(): void {

    }
    show(): void {
        this.active = true;
        this.modal.show();
        this.category = new CreateCategoryInput();
    }
    save() {
        this._categoryService.createAsync(this.category).pipe(finalize(() => {

        })).subscribe(() => {
            abp.notify.success('category saved!');
            this.close();
            window.setTimeout(() => {location.reload(); }, 3000) ;
        });
    }
    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
