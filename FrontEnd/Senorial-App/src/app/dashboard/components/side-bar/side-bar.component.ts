import { Component } from '@angular/core';

@Component({
  selector: 'side-bar',
  templateUrl: './side-bar.component.html',
  styleUrl: './side-bar.component.scss'
})
export class SideBarComponent {
  dropdowns: { [key: string]: boolean } = {};
  activeMenu: string | null = null;
  activeSubmenu: string | null = null;

  toggleDropdown(menu: string) {
    this.dropdowns[menu] = !this.dropdowns[menu];
    this.activeMenu = menu;
  }

  setActiveMenu(menu: string) {
    this.activeMenu = menu;
    this.activeSubmenu = null; // Reset active submenu
  }

  setActiveSubmenu(submenu: string) {
    this.activeSubmenu = submenu;

  }
}
