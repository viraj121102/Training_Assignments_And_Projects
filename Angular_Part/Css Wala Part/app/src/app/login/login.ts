import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  imports: [],
  templateUrl: './login.html',
styleUrl: './login.css'
//styleUrls:['./login.css','../app.css']
})
export class Login {
 users=["Viraj","Anil","Peter","Bruce","Tony"]

 students=[
  {name:"Viraj",rollno:30,age:22},
  {name:"Amit",rollno:38,age:24},
  {name:"Rohit",rollno:10,age:52},
  {name:"Sam",rollno:3,age:25},
 ]
}
