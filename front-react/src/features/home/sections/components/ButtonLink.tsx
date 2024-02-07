'use client';

import Button, {ButtonSlotsAndSlotProps, ButtonTypeMap} from "@mui/joy/Button";
import {redirect} from 'next/navigation'

interface IButtonLink {
    href: string,
    children: React.ReactNode,
    size: ButtonTypeMap['props']['size']
    color: ButtonTypeMap['props']['color']
    variant: ButtonTypeMap['props']['variant']
    // [key: keyof ButtonTypeMap['props']]: any
}

const ButtonLink: React.FC<IButtonLink> = (props) => {
    return (
        <Button
            variant={'solid'}

            onClick={() => {
                redirect(props.href)
            }}
            size={props.size}

        >
            {props.children}
        </Button>
    )
}

export default ButtonLink