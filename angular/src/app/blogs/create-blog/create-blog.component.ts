import { AppComponentBase } from 'shared/app-component-base';
import { CreateBlogInput, BlogServiceProxy, CategoryListDto, CategoryServiceProxy, AuthorServiceProxy, AuthorListDto } from './../../../shared/service-proxies/service-proxies';
import { Component, ViewChild, ElementRef, EventEmitter, Output, Injector, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';

@Component({
    selector: 'create-blog-modal',
    templateUrl: './create-blog.component.html',
    providers: [BlogServiceProxy, CategoryServiceProxy, AuthorServiceProxy]
})
export class CreateBlogComponent extends AppComponentBase implements OnInit {

    @ViewChild('createBlogModal') modal: ModalDirective;
    @ViewChild('modalContent') modalContent: ElementRef;
    @ViewChild('blogDate') eventDate: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active: boolean = false;
    saving: boolean = false;
    blog: CreateBlogInput = null;
    categories: CategoryListDto[] = [];
    authors: AuthorListDto[] = [];

    constructor(
        injector: Injector,
        private _blogService: BlogServiceProxy,
        private _categoryService: CategoryServiceProxy,
        private _authorService: AuthorServiceProxy
    ) {
        super(injector);
    }
    ngOnInit(): void {
        this.getCategories();
        this.getAuthors();
    }
    show(): void {
        this.active = true;
        this.modal.show();
        this.blog = new CreateBlogInput();
    }

    save() {
        this._blogService.createAsync(this.blog).pipe(finalize(() => {

        })).subscribe(() => {
            abp.notify.success('blog saved!');
        });
    }
    close(): void {
        this.active = false;
        this.modal.hide();
    }
    getCategories() {
        this._categoryService.getListAsync().subscribe(result => {
            this.categories = result.items;
        });
    }
    getAuthors() {
        this._authorService.getListAsync(false).subscribe(result => {console.log(result.items);
            this.authors = result.items;
        });
    }

}
