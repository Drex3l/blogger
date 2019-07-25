import { AthorDetailComponent } from './authors/author-detail/author-detail.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { JsonpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';

import { ModalModule } from 'ngx-bootstrap';
import { NgxPaginationModule } from 'ngx-pagination';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { AbpModule } from '@abp/abp.module';

import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';
import { SharedModule } from '@shared/shared.module';

import { HomeComponent } from '@app/home/home.component';
import { AboutComponent } from '@app/about/about.component';
import { TopBarComponent } from '@app/layout/topbar.component';
import { TopBarLanguageSwitchComponent } from '@app/layout/topbar-languageswitch.component';
import { SideBarUserAreaComponent } from '@app/layout/sidebar-user-area.component';
import { SideBarNavComponent } from '@app/layout/sidebar-nav.component';
import { SideBarFooterComponent } from '@app/layout/sidebar-footer.component';
import { RightSideBarComponent } from '@app/layout/right-sidebar.component';
// tenants
import { TenantsComponent } from '@app/tenants/tenants.component';
import { CreateTenantDialogComponent } from './tenants/create-tenant/create-tenant-dialog.component';
import { EditTenantDialogComponent } from './tenants/edit-tenant/edit-tenant-dialog.component';
// roles
import { RolesComponent } from '@app/roles/roles.component';
import { CreateRoleDialogComponent } from './roles/create-role/create-role-dialog.component';
import { EditRoleDialogComponent } from './roles/edit-role/edit-role-dialog.component';
// users
import { UsersComponent } from '@app/users/users.component';
import { CreateUserDialogComponent } from '@app/users/create-user/create-user-dialog.component';
import { EditUserDialogComponent } from '@app/users/edit-user/edit-user-dialog.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { ResetPasswordDialogComponent } from './users/reset-password/reset-password.component';
import { CategoriesComponent } from './categories/categories.component';
import { BlogsComponent } from './blogs/blogs.component';
import { AuthorsComponent } from './authors/authors.component';
import { CreateBlogComponent } from './blogs/create-blog/create-blog.component';
import { CreateCategoryComponent } from './categories/create-category/create-category.component';
import { CreateAuthorComponent } from './authors/create-author/create-author.component';
import { UpdateAuthorComponent } from './authors/update-author/update-author.component';

@NgModule({
   declarations: [
      AppComponent,
      HomeComponent,
      AboutComponent,
      TopBarComponent,
      TopBarLanguageSwitchComponent,
      SideBarUserAreaComponent,
      SideBarNavComponent,
      SideBarFooterComponent,
      RightSideBarComponent,
      //tenants\r\nTenantsComponent,
      CreateTenantDialogComponent,
      EditTenantDialogComponent,
      //roles\r\nRolesComponent,
      CreateRoleDialogComponent,
      EditRoleDialogComponent,
      //users\r\nUsersComponent,
      CreateUserDialogComponent,
      EditUserDialogComponent,
      ChangePasswordComponent,
      ResetPasswordDialogComponent,

      BlogsComponent,
         CreateBlogComponent,
      CategoriesComponent,
         CreateCategoryComponent,
      AuthorsComponent,
         CreateAuthorComponent,
         AthorDetailComponent,
         UpdateAuthorComponent,

      UsersComponent,
      RolesComponent,
      TenantsComponent
   ],
   imports: [
      CommonModule,
      FormsModule,
      ReactiveFormsModule,
      HttpClientModule,
      JsonpModule,
      ModalModule.forRoot(),
      AbpModule,
      AppRoutingModule,
      ServiceProxyModule,
      SharedModule,
      NgxPaginationModule
   ],
   providers: [],
   entryComponents: [
      //tenants\r\nCreateTenantDialogComponent,
      EditTenantDialogComponent,
      //roles\r\nCreateRoleDialogComponent,
      EditRoleDialogComponent,
      //users\r\nCreateUserDialogComponent,
      EditUserDialogComponent,
      CreateUserDialogComponent,
      ResetPasswordDialogComponent
   ]
})
export class AppModule {}
