È
NC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Services\AnnouncementService.cs
	namespace 	
YourOSBB
 
. 
Services 
; 
public 
class 
AnnouncementService  
:! " 
IAnnouncementService# 7
{ 
private		 
IUnitOfWork		 
_unitOfWork		 #
;		# $
public 

AnnouncementService 
( 
IUnitOfWork *

unitOfWork+ 5
)5 6
{ 
_unitOfWork 
= 

unitOfWork  
;  !
} 
public 

async 
Task 
Add 
( 
Announcement &
ent' *
)* +
{ 
await 
_unitOfWork 
. "
AnnouncementRepository 0
.0 1
AddAsync1 9
(9 :
ent: =
)= >
;> ?
await 
_unitOfWork 
. 
DoAsync !
(! "
)" #
;# $
} 
public 

async 
Task 
Delete 
( 
Announcement )
ent* -
)- .
{ 
await 
_unitOfWork 
. "
AnnouncementRepository 0
.0 1
DeleteAsync1 <
(< =
ent= @
)@ A
;A B
await 
_unitOfWork 
. 
DoAsync !
(! "
)" #
;# $
} 
public 

async 
Task 
< 
Announcement "
>" #
GetById$ +
(+ ,
int, /
id0 2
)2 3
{ 
return 
await 
_unitOfWork  
.  !"
AnnouncementRepository! 7
.7 8
GetByIdAsync8 D
(D E
idE G
)G H
;H I
} 
public!! 

async!! 
Task!! 
<!! 
IEnumerable!! !
<!!! "
Announcement!!" .
>!!. /
>!!/ 0
GetAll!!1 7
(!!7 8
)!!8 9
{"" 
return## 
await## 
_unitOfWork##  
.##  !"
AnnouncementRepository##! 7
.##7 8
GetAllAsync##8 C
(##C D
)##D E
;##E F
}$$ 
}%% Î
QC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Services\ApplicationUserService.cs
	namespace 	
YourOSBB
 
. 
Services 
; 
public		 
class		 "
ApplicationUserService		 #
:		$ %#
IApplicationUserService		& =
{

 
private 
IUnitOfWork 
_unitOfWork #
;# $
public 
"
ApplicationUserService !
(! "
IUnitOfWork" -

unitOfWork. 8
)8 9
{ 
_unitOfWork 
= 

unitOfWork  
;  !
} 
public 

async 
Task 
Add 
( 
ApplicationUser )
user* .
). /
{ 
await 
_unitOfWork 
. "
ApplicationUserManager 0
.0 1
CreateAsync1 <
(< =
user= A
)A B
;B C
await 
_unitOfWork 
. 
DoAsync !
(! "
)" #
;# $
} 
public 

async 
Task 
Delete 
( 
ApplicationUser ,
user- 1
)1 2
{ 
await 
_unitOfWork 
. "
ApplicationUserManager 0
.0 1
DeleteAsync1 <
(< =
user= A
)A B
;B C
await 
_unitOfWork 
. 
DoAsync !
(! "
)" #
;# $
} 
public 

async 
Task 
< 
ApplicationUser %
>% &
GetById' .
(. /
int/ 2
id3 5
)5 6
{ 
return   
await   
_unitOfWork    
.    !%
ApplicationUserRepository  ! :
.  : ;
GetByIdAsync  ; G
(  G H
id  H J
)  J K
;  K L
}!! 
public## 

async## 
Task## 
<## 
ApplicationUser## %
>##% &
GetById##' .
(##. /
string##/ 5
id##6 8
)##8 9
{$$ 
return%% 
await%% 
_unitOfWork%%  
.%%  !"
ApplicationUserManager%%! 7
.%%7 8
FindByIdAsync%%8 E
(%%E F
id%%F H
)%%H I
??%%J L
throw%%M R
new%%S V%
InvalidOperationException%%W p
(%%p q
)%%q r
;%%r s
}&& 
public(( 

async(( 
Task(( 
<(( 
IEnumerable(( !
<((! "
ApplicationUser((" 1
>((1 2
>((2 3
GetAll((4 :
(((: ;
)((; <
{)) 
return** 
await** 
_unitOfWork**  
.**  !%
ApplicationUserRepository**! :
.**: ;
GetAllAsync**; F
(**F G
)**G H
;**H I
}++ 
public-- 

UserManager-- 
<-- 
ApplicationUser-- &
>--& '
GetUserManager--( 6
(--6 7
)--7 8
{.. 
return// 
_unitOfWork// 
.// "
ApplicationUserManager// 1
;//1 2
}00 
public22 

Task22 
<22 
IEnumerable22 
<22 
ApplicationUser22 +
>22+ ,
>22, -!
GetAllResidentsInOsbb22. C
(22C D
int22D G
osbbId22H N
)22N O
{33 
return44 
_unitOfWork44 
.44 %
ApplicationUserRepository44 4
.444 5!
GetAllResidentsInOsbb445 J
(44J K
osbbId44K Q
)44Q R
;44R S
}55 
}66 ÿ
KC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Services\ComplaintService.cs
	namespace 	
YourOSBB
 
. 
Services 
; 
public 
class 
ComplaintService 
: 
IComplaintService  1
{ 
private		 
IUnitOfWork		 
_unitOfWork		 #
;		# $
public 

ComplaintService 
( 
IUnitOfWork '

unitOfWork( 2
)2 3
{ 
_unitOfWork 
= 

unitOfWork  
;  !
} 
public 

async 
Task 
< 
IEnumerable !
<! "
	Complaint" +
>+ ,
>, -
GetAll. 4
(4 5
)5 6
{ 
return 
await 
_unitOfWork  
.  !
ComplaintRepository! 4
.4 5
GetAllAsync5 @
(@ A
)A B
;B C
} 
public 

async 
Task 
Add 
( 
	Complaint #
	complaint$ -
)- .
{ 
await 
_unitOfWork 
. 
ComplaintRepository -
.- .
AddAsync. 6
(6 7
	complaint7 @
)@ A
;A B
await 
_unitOfWork 
. 
DoAsync !
(! "
)" #
;# $
} 
public 

async 
Task 
< 
	Complaint 
>  
GetById! (
(( )
int) ,
id- /
)/ 0
{ 
return 
await 
_unitOfWork  
.  !
ComplaintRepository! 4
.4 5
GetByIdAsync5 A
(A B
idB D
)D E
;E F
} 
public   

async   
Task   
Update   
(   
	Complaint   &
	complaint  ' 0
)  0 1
{!! 
await"" 
_unitOfWork"" 
."" 
ComplaintRepository"" -
.""- .
Update"". 4
(""4 5
	complaint""5 >
)""> ?
;""? @
await## 
_unitOfWork## 
.## 
DoAsync## !
(##! "
)##" #
;### $
}$$ 
}%% Ø
ZC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Services\Interfaces\IAnnouncementService.cs
	namespace 	
YourOSBB
 
. 
Services 
. 

Interfaces &
;& '
public 
	interface  
IAnnouncementService %
{ 
Task 
Add	 
( 
Announcement 
ent 
) 
; 
Task 
Delete	 
( 
Announcement 
ent  
)  !
;! "
Task		 
<		 	
Announcement			 
>		 
GetById		 
(		 
int		 "
id		# %
)		% &
;		& '
Task

 
<

 	
IEnumerable

	 
<

 
Announcement

 !
>

! "
>

" #
GetAll

$ *
(

* +
)

+ ,
;

, -
} Ì

]C:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Services\Interfaces\IApplicationUserService.cs
	namespace 	
YourOSBB
 
. 
Services 
. 

Interfaces &
;& '
public 
	interface #
IApplicationUserService (
{ 
Task		 
Add			 
(		 
ApplicationUser		 
user		 !
)		! "
;		" #
Task

 
Delete

	 
(

 
ApplicationUser

 
user

  $
)

$ %
;

% &
Task 
< 	
ApplicationUser	 
> 
GetById !
(! "
int" %
id& (
)( )
;) *
Task 
< 	
IEnumerable	 
< 
ApplicationUser $
>$ %
>% &
GetAll' -
(- .
). /
;/ 0
UserManager 
< 
ApplicationUser 
>  
GetUserManager! /
(/ 0
)0 1
;1 2
public 

Task 
< 
IEnumerable 
< 
ApplicationUser +
>+ ,
>, -!
GetAllResidentsInOsbb. C
(C D
intD G
osbbIdH N
)N O
;O P
} ©
WC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Services\Interfaces\IComplaintService.cs
	namespace 	
YourOSBB
 
. 
Services 
. 

Interfaces &
;& '
public 
	interface 
IComplaintService "
{ 
Task 
< 	
IEnumerable	 
< 
	Complaint 
> 
>  
GetAll! '
(' (
)( )
;) *
Task 
Add	 
( 
	Complaint 
	complaint  
)  !
;! "
Task		 
<		 	
	Complaint			 
>		 
GetById		 
(		 
int		 
id		  "
)		" #
;		# $
Task

 
Update

	 
(

 
	Complaint

 
	complaint

 #
)

# $
;

$ %
} Å
RC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Services\Interfaces\IOsbbService.cs
	namespace 	
YourOSBB
 
. 
Services 
. 

Interfaces &
;& '
public 
	interface 
IOsbbService 
{ 
Task 
< 	
IEnumerable	 
< 
Osbb 
> 
> 
GetAll "
(" #
)# $
;$ %
Task 
Add	 
( 
Osbb 
osbb 
) 
; 
Task		 
<		 	
Osbb			 
>		 
GetById		 
(		 
int		 
id		 
)		 
;		 
Task

 
Update

	 
(

 
Osbb

 
osbb

 
)

 
;

 
} °
VC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Services\Interfaces\IProposalService.cs
	namespace 	
YourOSBB
 
. 
Services 
. 

Interfaces &
;& '
public 
	interface 
IProposalService !
{ 
Task 
< 	
IEnumerable	 
< 
Proposal 
> 
> 
GetAll  &
(& '
)' (
;( )
Task 
Add	 
( 
Proposal 
proposal 
) 
;  
Task		 
<		 	
Proposal			 
>		 
GetById		 
(		 
int		 
id		 !
)		! "
;		" #
Task

 
Update

	 
(

 
Proposal

 
proposal

 !
)

! "
;

" #
} ë
TC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Services\Interfaces\ITariffService.cs
	namespace 	
YourOSBB
 
. 
Services 
. 

Interfaces &
;& '
public 
	interface 
ITariffService 
{ 
Task 
< 	
IEnumerable	 
< 
Tariff 
> 
> 
GetAll $
($ %
)% &
;& '
Task 
Add	 
( 
Tariff 
tariff 
) 
; 
Task		 
<		 	
Tariff			 
>		 
GetById		 
(		 
int		 
id		 
)		  
;		  !
Task

 
Update

	 
(

 
Tariff

 
tariff

 
)

 
;

 
} ¿
TC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Services\Interfaces\IVotingService.cs
	namespace 	
YourOSBB
 
. 
Services 
. 

Interfaces &
;& '
public 
	interface 
IVotingService 
{ 
Task 

CreatePoll	 
( 
Poll 
poll 
) 
; 
Task 
< 	
IEnumerable	 
< 
Poll 
> 
> 
ShowActiveOsbbPolls /
(/ 0
int0 3
osbbId4 :
): ;
;; <
Task		 
<		 	
IEnumerable			 
<		 
CompletedPoll		 "
>		" #
>		# $"
ShowCompletedOsbbPolls		% ;
(		; <
int		< ?
osbbId		@ F
)		F G
;		G H
Task

 
<

 	
Poll

	 
>

 
GetPollById

 
(

 
int

 
id

 !
)

! "
;

" #
Task 
< 	
PollCandidate	 
>  
GetPollCandidateById ,
(, -
int- 0
id1 3
)3 4
;4 5
Task 
< 	
IEnumerable	 
< 
PollCandidate "
>" #
># $)
GetManyPollCandidatesByPollId% B
(B C
intC F
idG I
)I J
;J K
Task 
VoteForCandidate	 
( 
int 
userId $
,$ %
PollCandidate& 3
pollCandidate4 A
)A B
;B C
} Ê
FC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Services\OsbbService.cs
	namespace 	
YourOSBB
 
. 
Services 
; 
public 
class 
OsbbService 
: 
IOsbbService '
{ 
private		 
IUnitOfWork		 
_unitOfWork		 #
;		# $
public 

OsbbService 
( 
IUnitOfWork "

unitOfWork# -
)- .
{ 
_unitOfWork 
= 

unitOfWork  
;  !
} 
public 

async 
Task 
< 
IEnumerable !
<! "
Osbb" &
>& '
>' (
GetAll) /
(/ 0
)0 1
=>2 4
await5 :
_unitOfWork; F
.F G
OsbbRepositoryG U
.U V
GetAllAsyncV a
(a b
)b c
;c d
public 

async 
Task 
Add 
( 
Osbb 
osbb #
)# $
{ 
await 
_unitOfWork 
. 
OsbbRepository (
.( )
AddAsync) 1
(1 2
osbb2 6
)6 7
;7 8
await 
_unitOfWork 
. 
DoAsync !
(! "
)" #
;# $
} 
public 

async 
Task 
< 
Osbb 
> 
GetById #
(# $
int$ '
id( *
)* +
{ 
return 
await 
_unitOfWork  
.  !
OsbbRepository! /
./ 0
GetByIdAsync0 <
(< =
id= ?
)? @
;@ A
} 
public 

async 
Task 
Update 
( 
Osbb !
osbb" &
)& '
{ 
await 
_unitOfWork 
. 
OsbbRepository (
.( )
Update) /
(/ 0
osbb0 4
)4 5
;5 6
await 
_unitOfWork 
. 
DoAsync !
(! "
)" #
;# $
}   
}!! »
JC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Services\ProposalService.cs
	namespace 	
YourOSBB
 
. 
Services 
; 
public 
class 
ProposalService 
: 
IProposalService /
{ 
private		 
IUnitOfWork		 
_unitOfWork		 #
;		# $
public 

ProposalService 
( 
IUnitOfWork &

unitOfWork' 1
)1 2
{ 
_unitOfWork 
= 

unitOfWork  
;  !
} 
public 

async 
Task 
< 
IEnumerable !
<! "
Proposal" *
>* +
>+ ,
GetAll- 3
(3 4
)4 5
{ 
return 
await 
_unitOfWork  
.  !
ProposalRepository! 3
.3 4
GetAllAsync4 ?
(? @
)@ A
;A B
} 
public 

async 
Task 
Add 
( 
Proposal "
proposal# +
)+ ,
{ 
await 
_unitOfWork 
. 
ProposalRepository ,
., -
AddAsync- 5
(5 6
proposal6 >
)> ?
;? @
await 
_unitOfWork 
. 
DoAsync !
(! "
)" #
;# $
} 
public 

async 
Task 
< 
Proposal 
> 
GetById  '
(' (
int( +
id, .
). /
{ 
return 
await 
_unitOfWork  
.  !
ProposalRepository! 3
.3 4
GetByIdAsync4 @
(@ A
idA C
)C D
;D E
} 
public   

async   
Task   
Update   
(   
Proposal   %
proposal  & .
)  . /
{!! 
await"" 
_unitOfWork"" 
."" 
ProposalRepository"" ,
."", -
Update""- 3
(""3 4
proposal""4 <
)""< =
;""= >
await## 
_unitOfWork## 
.## 
DoAsync## !
(##! "
)##" #
;### $
}$$ 
}%% ®
HC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Services\TariffService.cs
	namespace 	
YourOSBB
 
. 
Services 
; 
public 
class 
TariffService 
: 
ITariffService +
{ 
private		 
IUnitOfWork		 
_unitOfWork		 #
;		# $
public 

TariffService 
( 
IUnitOfWork $

unitOfWork% /
)/ 0
{ 
_unitOfWork 
= 

unitOfWork  
;  !
} 
public 

async 
Task 
< 
IEnumerable !
<! "
Tariff" (
>( )
>) *
GetAll+ 1
(1 2
)2 3
{ 
return 
await 
_unitOfWork  
.  !
TariffRepository! 1
.1 2
GetAllAsync2 =
(= >
)> ?
;? @
} 
public 

async 
Task 
Add 
( 
Tariff  
tariff! '
)' (
{ 
await 
_unitOfWork 
. 
TariffRepository *
.* +
AddAsync+ 3
(3 4
tariff4 :
): ;
;; <
await 
_unitOfWork 
. 
DoAsync !
(! "
)" #
;# $
} 
public 

async 
Task 
< 
Tariff 
> 
GetById %
(% &
int& )
id* ,
), -
{ 
return 
await 
_unitOfWork  
.  !
TariffRepository! 1
.1 2
GetByIdAsync2 >
(> ?
id? A
)A B
;B C
} 
public   

async   
Task   
Update   
(   
Tariff   #
tariff  $ *
)  * +
{!! 
await"" 
_unitOfWork"" 
."" 
TariffRepository"" *
.""* +
Update""+ 1
(""1 2
tariff""2 8
)""8 9
;""9 :
await## 
_unitOfWork## 
.## 
DoAsync## !
(##! "
)##" #
;### $
}$$ 
}%% Î(
HC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Services\VotingService.cs
	namespace 	
YourOSBB
 
. 
Services 
; 
public 
class 
VotingService 
: 
IVotingService +
{ 
private		 
IUnitOfWork		 
_unitOfWork		 #
;		# $
public 

VotingService 
( 
IUnitOfWork $

unitOfWork% /
)/ 0
{ 
_unitOfWork 
= 

unitOfWork  
;  !
} 
public 

async 
Task 

CreatePoll  
(  !
Poll! %
poll& *
)* +
{ 
await 
_unitOfWork 
. 
PollRepository (
.( )
AddAsync) 1
(1 2
poll2 6
)6 7
;7 8
await 
_unitOfWork 
. 
DoAsync !
(! "
)" #
;# $
} 
public 

async 
Task 
< 
IEnumerable !
<! "
Poll" &
>& '
>' (
ShowActiveOsbbPolls) <
(< =
int= @
osbbIdA G
)G H
{ 
var 
fetch 
= 
await 
_unitOfWork %
.% &
PollRepository& 4
.4 5
GetAllAsync5 @
(@ A
)A B
;B C
return 
fetch 
. 
Where 
( 
x 
=> 
x  !
.! "
OsbbId" (
==) +
osbbId, 2
)2 3
;3 4
} 
public 

async 
Task 
< 
IEnumerable !
<! "
CompletedPoll" /
>/ 0
>0 1"
ShowCompletedOsbbPolls2 H
(H I
intI L
osbbIdM S
)S T
{ 
var 
fetch 
= 
await 
_unitOfWork %
.% &#
CompletedPollRepository& =
.= >
GetAllAsync> I
(I J
)J K
;K L
return   
fetch   
.   
Where   
(   
x   
=>   
x    !
.  ! "
OsbbId  " (
==  ) +
osbbId  , 2
)  2 3
;  3 4
}!! 
public## 

async## 
Task## 
<## 
Poll## 
>## 
GetPollById## '
(##' (
int##( +
id##, .
)##. /
{$$ 
return%% 
await%% 
_unitOfWork%%  
.%%  !
PollRepository%%! /
.%%/ 0
GetByIdAsync%%0 <
(%%< =
id%%= ?
)%%? @
;%%@ A
}&& 
public(( 

async(( 
Task(( 
<(( 
PollCandidate(( #
>((# $ 
GetPollCandidateById((% 9
(((9 :
int((: =
id((> @
)((@ A
{)) 
return** 
await** 
_unitOfWork**  
.**  !#
PollCandidateRepository**! 8
.**8 9
GetByIdAsync**9 E
(**E F
id**F H
)**H I
;**I J
}++ 
public-- 

async-- 
Task-- 
<-- 
IEnumerable-- !
<--! "
PollCandidate--" /
>--/ 0
>--0 1)
GetManyPollCandidatesByPollId--2 O
(--O P
int--P S
id--T V
)--V W
{.. 
var// 
temp// 
=// 
await// 
_unitOfWork// $
.//$ %#
PollCandidateRepository//% <
.//< =
GetAllAsync//= H
(//H I
)//I J
;//J K
return00 
temp00 
.00 
Where00 
(00 
x00 
=>00 
x00  
.00  !
PollId00! '
==00( *
id00+ -
)00- .
.00. /
ToList00/ 5
(005 6
)006 7
;007 8
}11 
public33 

async33 
Task33 
VoteForCandidate33 &
(33& '
int33' *
userId33+ 1
,331 2
PollCandidate333 @
pollCandidate33A N
)33N O
{44 
await55 
_unitOfWork55 
.55 
UserVoteRepository55 ,
.66 
AddAsync66 
(66 
new66 
UserVote66 "
{77 
UserId88 
=88 
userId88 
,88  
PollCandidateId99 
=99  !
pollCandidate99" /
.99/ 0
Id990 2
,992 3
PollCandidate:: 
=:: 
pollCandidate::  -
};; 
);; 
;;; 
await<< 
_unitOfWork<< 
.<< 
DoAsync<< !
(<<! "
)<<" #
;<<# $
}== 
}>> 