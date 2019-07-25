import { AppComponentBase } from 'shared/app-component-base';
import { BlogServiceProxy, BlogListDto, EntityDtoOfGuid } from './../../shared/service-proxies/service-proxies';
import { Component, ViewChild, Injector } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { CreateBlogComponent } from './create-blog/create-blog.component';

@Component({
  selector: 'app-blogs',
  templateUrl: './blogs.component.html',
  animations: [appModuleAnimation()],
  providers: [BlogServiceProxy]
})
export class BlogsComponent extends AppComponentBase {
  @ViewChild('createBlogModal') createBlogModal: CreateBlogComponent;
  active: boolean = false;
  blogs: BlogListDto[] = [];
  includeCanceledBlogs: boolean = false;

  constructor(
    injector: Injector,
    private _blogService: BlogServiceProxy
    ) {
      super(injector);
     }


     // Show Modals
    createBlog(): void {
      this.createBlogModal.show();
    }

  refresh() {
    location.reload();
  }
  loadEvent() {
    this._blogService.getListAsync(this.includeCanceledBlogs)
        .subscribe((result) => {
            this.blogs = result.items;
        });
}
     protected delete(blog: EntityDtoOfGuid): void {
      abp.message.confirm(
          'Are you sure you want to cancel this event?',
          (result: boolean) => {
              if (result) {
                  this._blogService.cancelAsync(blog)
                      .subscribe(() => {
                          abp.notify.info('Blog is deleted');
                          this.refresh();
                      });
              }
          }
      );
  }
}
