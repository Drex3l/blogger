import { CategoryServiceProxy, CategoryListDto } from './../../shared/service-proxies/service-proxies';
import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import { CreateCategoryComponent } from './create-category/create-category.component';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  animations: [appModuleAnimation()],
  providers: [CategoryServiceProxy]
})
export class CategoriesComponent extends AppComponentBase implements OnInit {
  @ViewChild('createCategoryModal') createCategoryModal: CreateCategoryComponent;
  categories: CategoryListDto[] = [];
  constructor(
    injector: Injector,
    private _categoryService: CategoryServiceProxy
  ) {
    super(injector);
  }

  ngOnInit() {
    this.loadEvent();
  }
  loadEvent() {
    this._categoryService.getListAsync().subscribe((result) => { this.categories = result.items; });
  }
  // Show Modals
  createCategory(): void {
    this.createCategoryModal.show();
  }
  refresh() {
    location.reload();
  }
  deleteCategory(cat: any): void {
    abp.message.confirm(
      this.l('Delete Category? ' + cat.title),
      (result: boolean) => {
        if (result) {
          this._categoryService.deleteAsync(cat.id).subscribe(() => {
            abp.notify.success(this.l('Successfully Deleted'));
            this.loadEvent();
          });
        }
      }
    );
  }
}
