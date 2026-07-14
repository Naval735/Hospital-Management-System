import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Auth } from '../../core/services/auth';
@Component({
  selector: 'app-dashboard',
  imports: [],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss',
})
export class Dashboard {

  name: string = '';
  role: string = '';
upcomingAppointments = 1;

prescriptions = 5;

medicalRecords = 8;

medicalReports = 4;
  constructor(
    private auth:Auth,
    private router: Router
  ) {}

  ngOnInit(): void {

    this.name = localStorage.getItem('name') || '';
    this.role = localStorage.getItem('role') || '';

  } 

  logout(): void{
    this.auth.logout();
    this.router.navigate(['/login']);
  }
}
