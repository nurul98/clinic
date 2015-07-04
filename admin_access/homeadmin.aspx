<%@ Page Title="" Language="C#" MasterPageFile="~/admin_access/admin.Master" AutoEventWireup="true" CodeBehind="homeadmin.aspx.cs" Inherits="clinic.admin_access.homeadmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div class="articleboxinner">

        <div class="articleboxinner">

            <!-- The flower image. 300px by 200px -->
            <img src="images/drlee.jpg" alt="help" class="mainpiccontrol" />
            <span class="articleheader">Welcome to CCBS</span>
            <br />

            <!-- The preview content -->
            Clinic Consultation Booking System (CCBS) is a system solution which manages the patient 
            reservation or booking for medical consultation. The patient needs to register to be an authorized user 
            before proceeds with the system. The system will help the patients to plan when to meet their preferred 
            doctor in which to assist the patient for further consults.
            <br />

            <!-- Link to the full article, an arrow and a text link -->
            <span class="readmore">
               
                <!-- <a href="#">Read More</a> -->
                <br />&nbsp;
            </span>
        </div>
        </div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 

       <!-- End of main article -->

    <!-- Here's the box for some pics, remove if not a photo gallery -->
    <div class="picboxouter">

        <!-- Here's where you can place ur thumbnails -->
        <!-- All should be uniformly sized ;-) -->
        <div class="picbox">

            &nbsp;</a>&nbsp;
            <img src="images/p1.jpg" alt="help" class="pickboxcontrol" />
            <img src="images/p6.jpg" alt="help" class="pickboxcontrol" />
            <img src="images/p3.jpg" alt="help" class="pickboxcontrol" />
            <img src="images/p4.jpg" alt="help" class="pickboxcontrol" />
            <img src="images/p5.jpg" alt="help" class="pickboxcontrol" />
            &nbsp;

        </div>
    </div>
    <!-- End of photogallery -->

    <!-- We love three columns, don't we? -->
    <!-- Holder for three columns -->
    <div class="articleboxouter">
        <div id="newsContainer2">

            <!-- Column 1 -->
    		<div class="c1">
    			<div class="noteheader">
    				&nbsp;Objectives
    			</div>
    			<div class="spacy">
                    The Objectives are: 
                    1)To provide an online monitoring booking system used by clinic administrator, 
                    doctor and patient for clinic application with learnable interface platform for ease of use.
                    2)To help doctors in planning his/her schedule on consultation session 
                    to avoid customer come back if the desired booking date is full booked.
    			</div>
    		</div>

    		<!-- Column 2 -->
            <div class="c2">
                <div class="noteheader">
                    &nbsp;System Scopes
                </div>
                <div class="spacy">
                    Systems scopes that have been identified for this project are:
                    The study of this project is based on the clinic consultation booking system for clinic application.
                    This system will handle information which is obtained preferred 
                    doctor chosen by patient, and also the date and time booked based on the availability of the doctor.

                </div>
            </div>

            <!-- Column 3 -->
    		<div class="c3">
                <div class="noteheader">
                    &nbsp;Patient's Benefits
                </div>
              <div class="spacy">
    			<!-- The content for this attention grabbing block -->
                    These are benefits identified for this project:
                    1)To assist in booking the consultation session so that the patient does not need to come 
                    to the clinic and make a phone call to make the reservation.
                    2)To ensure that the development of the system is in line with the need from the patient 
                    that requires such clinic application nowadays.

 <br />
              </div>
            </div>
        </div>
    </div>
    <!-- End of the three columns holder -->

   <!-- End of master container -->
</asp:Content>

