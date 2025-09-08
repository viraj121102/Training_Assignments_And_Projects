import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: false,
  styleUrl: './app.css',
})
export class App {
 // protected readonly title = signal('FirstApp');
  title="Viraj"; // properties or isko agr print krna hai to html mein jaake {{title}} likh do ye kaam krega
  // function creation 
  // handleClick()
  // {
  //  alert('Function Called');
  //  // to call another func in this func we use this 
  //  this.otherFunc();
  // }
  // otherFunc()
  // {
  //   alert('Other function');
  // }

  //properties --->

  // //   x:number=30;
  // y:number|string=30;

  // update()
  // {
  //   //this.x="abc" -> this will give an error because we can not assign a string variable to a number value 
  //   this.y='abc';//here it is possible because we define it can be off multiple type
  // }
  // Sum(a:number,b:number)
  // {
  // alert(a+b);
  // }

  // Events 

  // handleEvent(event:Event)
  // { 
  //   console.log("Function called ",event.type);
  //   console.log(event.target);
  // }


  // Get and Set method 

  // get 
name:string="";
displayName:string="";
  getInput(event:Event)
  {
//console.log(event.type);
   const val=(event.target as HTMLInputElement).value
   this.name=val;
  }
  showOnClick()
  {
this.displayName=this.name;
  }
  setValue()
  {
    this.name='viraj';
  }
  email="";
  getEmail(val:string)
  {
  this.email=val;
  }
  setEmail()
  {
    this.email="test@gmail.com"
  }
 
  Sum(a:number,b:number)
  {
    console.log(a+b);
  }
  
  handleEvent(event:Event)
  {
   const val= (event.target as HTMLInputElement).value;
   console.log(val);
   this.nameChahiye=val;
  }
  nameChahiye:any;
  onbutton()
  {
    console.log('the value is :',this.nameChahiye);
  }
}
